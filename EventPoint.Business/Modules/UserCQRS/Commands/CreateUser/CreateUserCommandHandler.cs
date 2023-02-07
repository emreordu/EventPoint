using AutoMapper;
using EventPoint.Entity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventPoint.Business.Modules.UserCQRS.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        public CreateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return false;
            }
            if (IsUniqueUser(request.Email))
            {
                User user = new()
                {
                    Email = request.Email,
                    Name = request.Name,
                    LastName = request.LastName,
                    UserName = request.Email,
                    NormalizedEmail = request.Email.ToUpper()
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    if (request.Role == "admin")
                    {
                        await _userManager.AddToRoleAsync(user, "admin");
                    }
                    await _userManager.AddToRoleAsync(user, "participant");
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool IsUniqueUser(string username)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Email == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }
    }
}