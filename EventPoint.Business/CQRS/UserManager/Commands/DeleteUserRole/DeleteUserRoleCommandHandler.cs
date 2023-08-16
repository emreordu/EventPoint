using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.UserManager.Commands.DeleteUserRole
{
    public class DeleteUserRoleCommandHandler : ICommandHandler<DeleteUserRoleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<UserRole> roleRepository;
        public DeleteUserRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            roleRepository = _unitOfWork.GetRepository<UserRole>();
        }

        public async Task<bool> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            var model = await roleRepository.GetFirstOrDefaultAsync(x => x.UserId == request.UserId && x.RoleId == request.RoleId);
            if (model == null)
            {
                throw new Exception("Invalid Request.");
            }
            await roleRepository.DeleteAsync(model);
            return true;
        }
    }
}