using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : ICommandHandler<DeleteEventCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<Event> eventRepository;
        public DeleteEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            eventRepository = _unitOfWork.GetRepository<Event>();
        }
        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = eventRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id).Result;
            if (isDeleted == null)
            {
                return false;
            }
            await eventRepository.DeleteAsync(isDeleted);
            _unitOfWork.Commit();
            return true;
        }
    }
}