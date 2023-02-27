using FluentValidation;

namespace EventPoint.Business.CQRS.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandValidator : AbstractValidator<RevokeRefreshTokenCommand>
    {
        public RevokeRefreshTokenCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
        }
    }
}