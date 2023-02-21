using AutoMapper;
using EventPoint.Business.Dto;
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
        public UpdateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventRepository = _unitOfWork.GetRepository<Event>();
        }
        public async Task<EventDTO> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var isUpdated = await eventRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if(isUpdated == null)
            {
                throw new Exception("No event found. Please make a valid request.");
            }
            isUpdated.EventDate = request.EventDate;
            isUpdated.Name= request.Name;
            isUpdated.Description= request.Description;
            isUpdated.ParticipantLimit = request.ParticipantLimit;

            var model = await eventRepository.UpdateAsync(isUpdated);
            return _mapper.Map<EventDTO>(model);
        }
    }
}