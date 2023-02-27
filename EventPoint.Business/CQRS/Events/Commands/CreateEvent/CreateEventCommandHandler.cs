using AutoMapper;
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
        public CreateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventRepository = _unitOfWork.GetRepository<Event>();
        }
        public async Task<bool> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var mapEventRequest = _mapper.Map<Event>(request);
            if (mapEventRequest == null)
            {
                return false;
            }
            await eventRepository.CreateAsync(mapEventRequest);
            return true;
        }
    }
}