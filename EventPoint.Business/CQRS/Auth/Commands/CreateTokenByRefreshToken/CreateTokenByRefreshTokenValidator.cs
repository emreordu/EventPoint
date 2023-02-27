using FluentValidation;

namespace EventPoint.Business.CQRS.Auth.Commands.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenValidator:AbstractValidator<CreateTokenByRefreshTokenCommand>
    {
        public CreateTokenByRefreshTokenValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
        }
    }
}