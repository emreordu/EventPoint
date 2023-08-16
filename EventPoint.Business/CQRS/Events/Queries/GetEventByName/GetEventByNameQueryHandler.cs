using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Events.Queries.GetEventByName
{
    public class GetEventByNameQueryHandler : IQueryHandler<GetEventByNameQuery, EventDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<Event> eventRepository;
        public GetEventByNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventRepository = _unitOfWork.GetRepository<Event>();
        }

        public async Task<EventDTO> Handle(GetEventByNameQuery request, CancellationToken cancellationToken)
        {
            var model = await eventRepository.GetFirstOrDefaultAsync(x=>x.Name== request.Name);
            if (model == null)
            {
                throw new InvalidDataException("No event found. Please make a valid request.");
            }
            var mapModel = _mapper.Map<EventDTO>(model);
            return mapModel;
        }
    }
}