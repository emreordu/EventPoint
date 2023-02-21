using AutoMapper;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPoint.Business.CQRS.EventManager.Commands.AddParticipant
{
    public class AddParticipantCommandHandler : ICommandHandler<AddParticipantCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<EventUser> eventUserRepository;
        private readonly Repository<Event> eventRepository;
        public AddParticipantCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventUserRepository = _unitOfWork.GetRepository<EventUser>();
            eventRepository = _unitOfWork.GetRepository<Event>();
        }
        public async Task<bool> Handle(AddParticipantCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<EventUser>(request);
            if (model == null)
            {
                return false;
            }
            var isExceed = await IsLimitExceed(model.EventId);
            if (isExceed==false)
            {
                await eventUserRepository.CreateAsync(model);
                await _unitOfWork.CommitAsync(cancellationToken);
                return true;
            }
            return false;
        }
        private async Task<bool> IsLimitExceed(int eventId)
        {
            //var model = await _dbContext.Events.Include(n => n.EventUsers).ThenInclude(e => e.User)
            //    .FirstOrDefaultAsync(e => e.Id == eventId);
            var model = await eventRepository.GetFirstOrDefaultAsync(e => e.Id == eventId, include: x => x.Include(y => y.EventUsers));
            
            if (model == null)
            {
                return false;
            }
            var userList = model.EventUsers;
            if (userList.Count >= model.ParticipantLimit)
            {
                return true;
            }
            return false;
        }
    }
}