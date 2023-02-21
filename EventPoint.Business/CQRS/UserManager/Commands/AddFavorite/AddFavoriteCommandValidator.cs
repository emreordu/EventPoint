using FluentValidation;

namespace EventPoint.Business.CQRS.UserManager.Commands.AddFavorite
{
    public class AddFavoriteCommandValidator:AbstractValidator<AddFavoriteCommand>
    {
        public AddFavoriteCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EventId).NotEmpty().GreaterThan(0);
        }
    }
}