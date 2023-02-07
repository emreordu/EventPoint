using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Modules.EventCQRS.Queries.Requests;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using MediatR;

namespace EventPoint.Business.Modules.EventCQRS.Queries.GetEvents
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, List<EventDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<Event> eventRepository;
        public GetEventsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            eventRepository= _unitOfWork.GetRepository<Event>();
        }

        public async Task<List<EventDTO>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await eventRepository.GetAllAsync();
            if(events.Any())
            {
                var mapEvents = _mapper.Map<List<EventDTO>>(events);
                return mapEvents;
            }
            throw new InvalidOperationException();
        }
    }
}