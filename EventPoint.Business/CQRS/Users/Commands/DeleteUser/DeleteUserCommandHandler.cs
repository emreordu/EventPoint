using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<User> userRepository;
        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            userRepository = _unitOfWork.GetRepository<User>();
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetFirstOrDefaultAsync(x=>x.Id== request.Id);
            if (user == null)
            {
                return false;
            }
            await userRepository.DeleteAsync(user);
            _unitOfWork.Commit();
            return true;
        }
    }
}