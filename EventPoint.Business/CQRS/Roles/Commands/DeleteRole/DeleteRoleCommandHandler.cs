using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<Role> roleRepository;
        public DeleteRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            roleRepository = _unitOfWork.GetRepository<Role>();
        }
        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await roleRepository.GetFirstOrDefaultAsync(x => x.Name == request.Name);
            if (role == null)
            {
                throw new InvalidDataException("No role found. Please make a valid request.");
            }
            await roleRepository.DeleteAsync(role);
            return true;
        }
    }
}