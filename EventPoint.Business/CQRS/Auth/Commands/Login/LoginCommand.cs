using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Auth.Commands.Login
{
    public class LoginCommand : ICommand<TokenDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}