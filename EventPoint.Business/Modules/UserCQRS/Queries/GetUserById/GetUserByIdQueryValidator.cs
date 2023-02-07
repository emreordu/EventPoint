using FluentValidation;

namespace EventPoint.Business.Modules.UserCQRS.Queries.GetUserById
{
    public class GetUserByIdQueryValidator:AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}