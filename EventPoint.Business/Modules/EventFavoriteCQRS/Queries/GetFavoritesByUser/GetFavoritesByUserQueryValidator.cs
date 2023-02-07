using FluentValidation;

namespace EventPoint.Business.Modules.EventFavoriteCQRS.Queries.GetFavoritesByUser
{
    public class GetFavoritesByUserQueryValidator:AbstractValidator<GetFavoritesByUserQuery>
    {
        public GetFavoritesByUserQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
        }
    }
}