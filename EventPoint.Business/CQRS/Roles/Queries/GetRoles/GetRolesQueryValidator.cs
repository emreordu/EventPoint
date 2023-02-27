using FluentValidation;

namespace EventPoint.Business.CQRS.Roles.Queries.GetRoles
{
    public class GetRolesQueryValidator : AbstractValidator<GetRolesQuery>
    {
        public GetRolesQueryValidator()
        {
            RuleFor(x => x.PageSize).GreaterThan(0);
            RuleFor(x => x.PageNumber).GreaterThan(0);
        }
    }
}