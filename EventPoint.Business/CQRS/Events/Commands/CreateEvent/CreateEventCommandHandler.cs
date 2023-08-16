using AutoMapper;
using EventPoint.Business.Helpers.Models;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : ICommandHandler<CreateEventCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<Event> eventRepository;
        private readonly Repository<User> userRepository;
        private readonly IGetCurrentUser _getUserService;
        public CreateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IGetCurrentUser getUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventRepository = _unitOfWork.GetRepository<Event>();
            userRepository = _unitOfWork.GetRepository<User>();
            _getUserService = getUserService;
        }
        public async Task<bool> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _getUserService.GetLoginUser();
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Id == Convert.ToInt32(currentUserId));
            if (user == null)
            {
                throw new InvalidDataException("User not found.");
            }
            var model = _mapper.Map<Event>(request);
            if (model == null)
            {
                throw new InvalidDataException("Request is null.");
            }
            model.OwnerId = user.Id;
            await eventRepository.CreateAsync(model);
            return true;
        }
    }
}