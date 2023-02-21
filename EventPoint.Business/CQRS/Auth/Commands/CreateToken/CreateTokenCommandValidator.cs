using FluentValidation;

namespace EventPoint.Business.CQRS.Auth.Commands.CreateToken
{
    public class CreateTokenCommandValidator:AbstractValidator<CreateTokenCommand>
    {
        public CreateTokenCommandValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x=> x.Password).NotEmpty().NotNull().MinimumLength(8);
        }
    }
}