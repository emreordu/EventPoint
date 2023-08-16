using EventPoint.Business.Helpers.Models;
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
        private readonly Repository<User> userRepository;
        private readonly IGetCurrentUser _getUserService;
        public DeleteEventCommandHandler(IUnitOfWork unitOfWork, IGetCurrentUser getUserService)
        {
            _unitOfWork = unitOfWork;
            eventRepository = _unitOfWork.GetRepository<Event>();
            userRepository = _unitOfWork.GetRepository<User>();
            _getUserService = getUserService;
        }
        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _getUserService.GetLoginUser();
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Id == Convert.ToInt32(currentUserId));
            if (user == null)
            {
                throw new InvalidDataException("User not found.");
            }
            var isDeleted = await eventRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if (isDeleted == null)
            {
                throw new InvalidDataException("No event found. Please make a valid request.");
            }
            if (user.Id == isDeleted.OwnerId)
            {
                await eventRepository.DeleteAsync(isDeleted);
                return true;
            }
            throw new InvalidDataException("Invalid request. Make sure you're logged in with owner of the event.");
        }
    }
}