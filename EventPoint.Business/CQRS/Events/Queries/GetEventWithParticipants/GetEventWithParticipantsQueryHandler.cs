using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPoint.Business.CQRS.Events.Queries.GetEventWithParticipants
{
    public class GetEventWithParticipantsQueryHandler : IQueryHandler<GetEventWithParticipantsQuery, EventDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<Event> eventRepository;
        public GetEventWithParticipantsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventRepository = _unitOfWork.GetRepository<Event>();
        }
        public async Task<EventDTO> Handle(GetEventWithParticipantsQuery request, CancellationToken cancellationToken)
        {
            var model = await eventRepository.GetFirstOrDefaultAsync(e => e.Id == request.EventId,
                include: x => x.Include(y => y.EventUsers).ThenInclude(z => z.User));
            if (model == null)
            {
                throw new InvalidDataException("No event found. Please make a valid request.");
            }
            var userList = model.EventUsers;
            var eventDTO = _mapper.Map<EventDTO>(model);
            foreach (var user in userList)
            {
                if (user != null)
                {
                    eventDTO.Participants.Add(new ParticipantDTO { UserId = user.UserId, FirstName = user.User.FirstName, LastName = user.User.LastName });
                }
            }
            return eventDTO;
        }
    }
}