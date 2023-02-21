using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.EventManager.Commands.DeleteParticipant
{
    public class DeleteParticipantCommandHandler : ICommandHandler<DeleteParticipantCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<EventUser> eventUserRepository;
        public DeleteParticipantCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            eventUserRepository = _unitOfWork.GetRepository<EventUser>();
        }

        public async Task<bool> Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
        {
            var model = await eventUserRepository.GetFirstOrDefaultAsync(x => x.UserId == request.UserId && x.EventId == request.EventId);
            if(model == null)
            {
                return false;
            }
            await eventUserRepository.DeleteAsync(model);
            return true;
        }
    }
}