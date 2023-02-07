using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using MediatR;

namespace EventPoint.Business.Modules.EventUserCQRS.Queries.GetParticipants
{
    public class GetParticipantsQueryHandler : IRequestHandler<GetParticipantsQuery, List<ParticipateEventDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<EventUser> eventUserRepository;
        public GetParticipantsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventUserRepository = _unitOfWork.GetRepository<EventUser>();
        }
        public async Task<List<ParticipateEventDTO>> Handle(GetParticipantsQuery request, CancellationToken cancellationToken)
        {
            var eventList = await eventUserRepository.GetAllAsync();
            return _mapper.Map<List<ParticipateEventDTO>>(eventList);
        }
    }
}