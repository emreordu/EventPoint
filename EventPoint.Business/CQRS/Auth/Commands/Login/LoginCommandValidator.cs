using EventPoint.Business.CQRS.Auth.Commands.Login;
using FluentValidation;

namespace EventPoint.Business.CQRS.Auth.Commands.CreateToken
{
    public class LoginCommandValidator:AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x=> x.Password).NotEmpty().NotNull().MinimumLength(8);
        }
    }
}