using AutoMapper;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<Role> roleRepository;
        public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            roleRepository = _unitOfWork.GetRepository<Role>();
        }
        public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var newRole = _mapper.Map<Role>(request);
            if (newRole == null)
            {
                return false;
            }
            await roleRepository.CreateAsync(newRole);
            return true;
        }
    }
}