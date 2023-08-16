using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.UserManager.Commands.DeleteFavorite
{
    public class DeleteFavoriteCommandHandler : ICommandHandler<DeleteFavoriteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<EventFavorite> eventFavoriteRepository;
        public DeleteFavoriteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            eventFavoriteRepository = _unitOfWork.GetRepository<EventFavorite>();
        }

        public async Task<bool> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
        {
            var model = await eventFavoriteRepository.GetFirstOrDefaultAsync(x => x.UserId == request.UserId && x.EventId == request.EventId);
            if (model == null)
            {
                throw new InvalidDataException("Invalid request.");
            }
            await eventFavoriteRepository.DeleteAsync(model);
            return true;
        }
    }
}