using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.UserManager.Commands.LeaveEvent
{
    public class LeaveEventCommandHandler : ICommandHandler<LeaveEventCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<EventUser> eventUserRepository;
        public LeaveEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            eventUserRepository = _unitOfWork.GetRepository<EventUser>();
        }

        public async Task<bool> Handle(LeaveEventCommand request, CancellationToken cancellationToken)
        {
            var model = await eventUserRepository.GetFirstOrDefaultAsync(x => x.UserId == request.UserId && x.EventId == request.EventId);
            if (model == null)
            {
                throw new Exception("Invalid Request");
            }
            await eventUserRepository.DeleteAsync(model);
            return true;
        }
    }
}