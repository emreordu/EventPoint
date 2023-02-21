using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace EventPoint.Business.CQRS.EventManager.Queries.GetEventWithParticipants
{
    public class GetEventWithParticipantsQueryHandler : IQueryHandler<GetEventWithParticipantsQuery, EventDTO>
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public GetEventWithParticipantsQueryHandler(IMapper mapper, ApplicationDbContext dbContext)
        {
            //_unitOfWork = unitOfWork;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<EventDTO> Handle(GetEventWithParticipantsQuery request, CancellationToken cancellationToken)
        {
            var model = _dbContext.Events.Include(n => n.EventUsers).ThenInclude(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == request.EventId).Result;
            if (model == null)
            {
                return new EventDTO();
            }
            var userList = model.EventUsers;
            var eventDTO = _mapper.Map<EventDTO>(model);
            foreach (var user in userList)
            {
                if (user != null)
                {
                    eventDTO.Participants.Add(new ParticipantDTO { UserId = user.UserId, Name = user.User.Name, LastName = user.User.LastName });
                }
            }
            return eventDTO;
        }
    }
}