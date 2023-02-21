using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;
using EventPoint.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace EventPoint.Business.CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, UserDTO>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return new UserDTO();
            }
            user.Name = request.Name;
            user.Email = request.Email;
            user.LastName = request.LastName;
            user.UserName = request.Email;
            var hasher = _userManager.PasswordHasher.HashPassword(user, request.Password);
            user.PasswordHash = hasher;
            await _userManager.UpdateAsync(user);
            return _mapper.Map<UserDTO>(user);
        }
    }
}