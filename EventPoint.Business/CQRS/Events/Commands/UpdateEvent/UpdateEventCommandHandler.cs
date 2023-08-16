using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Helpers.Models;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : ICommandHandler<UpdateEventCommand, EventDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<Event> eventRepository;
        private readonly Repository<User> userRepository;
        private readonly IGetCurrentUser _getUserService;
        public UpdateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IGetCurrentUser getUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventRepository = _unitOfWork.GetRepository<Event>();
            userRepository = _unitOfWork.GetRepository<User>();
            _getUserService = getUserService;
        }
        public async Task<EventDTO> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _getUserService.GetLoginUser();
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Id == Convert.ToInt32(currentUserId));
            if (user == null)
            {
                throw new InvalidDataException("User not found.");
            }
            var isUpdated = await eventRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if (isUpdated == null)
            {
                throw new InvalidDataException("No event found. Please make a valid request.");
            }
            if (isUpdated.OwnerId != user.Id)
            {
                throw new InvalidDataException("Invalid request. Make sure you're logged in with owner of the event.");
            }
            isUpdated.EventDate = request.EventDate;
            isUpdated.Name = request.Name;
            isUpdated.Description = request.Description;
            isUpdated.ParticipantLimit = request.ParticipantLimit;

            var model = await eventRepository.UpdateAsync(isUpdated);
            return _mapper.Map<EventDTO>(model);
        }
    }
}