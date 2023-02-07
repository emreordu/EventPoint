using AutoMapper;
using EventPoint.Entity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventPoint.Business.Modules.UserCQRS.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return false;
            }
            var result = await _userManager.DeleteAsync(user);
            if(result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}