using FluentValidation;

namespace EventPoint.Business.CQRS.Events.Queries.GetEventByName
{
    public class GetEventByNameQueryValidator:AbstractValidator<GetEventByNameQuery>
    {
        public GetEventByNameQueryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().NotNull().MinimumLength(2);
        }
    }
}