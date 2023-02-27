using AutoMapper;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.UserManager.Commands.AddUserRole
{
    public class AddUserRoleCommandHandler : ICommandHandler<AddUserRoleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<UserRole> userRoleRepository;
        private readonly Repository<User> userRepository;
        private readonly Repository<Role> roleRepository;
        public AddUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            userRoleRepository = _unitOfWork.GetRepository<UserRole>();
            userRepository = _unitOfWork.GetRepository<User>();
            roleRepository = _unitOfWork.GetRepository<Role>();
        }

        public async Task<bool> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null)
            {
                throw new Exception("No user found.");
            }
            var role = await roleRepository.GetFirstOrDefaultAsync(x => x.Id == request.RoleId);
            if (role == null)
            {
                throw new Exception("No role found.");
            }
            var model = _mapper.Map<UserRole>(request);
            if (model == null)
            {
                throw new Exception("Invalid request.");
            }
            await userRoleRepository.CreateAsync(model);
            return true;
        }
    }
}