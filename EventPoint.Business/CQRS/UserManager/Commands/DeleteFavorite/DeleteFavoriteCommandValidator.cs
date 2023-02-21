using FluentValidation;

namespace EventPoint.Business.CQRS.UserManager.Commands.DeleteFavorite
{
    public class DeleteFavoriteCommandValidator: AbstractValidator<DeleteFavoriteCommand>
    {
        public DeleteFavoriteCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EventId).NotEmpty().GreaterThan(0);
        }
    }
}