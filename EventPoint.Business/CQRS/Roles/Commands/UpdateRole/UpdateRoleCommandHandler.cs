using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<Role> roleRepository;
        public UpdateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            roleRepository = _unitOfWork.GetRepository<Role>();
        }
        public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var isUpdated = await roleRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if (isUpdated == null)
            {
                throw new InvalidDataException("No role found. Please make a valid request.");
            }
            isUpdated.Name = request.Name;
            await roleRepository.UpdateAsync(isUpdated);
            return true;
        }
    }
}