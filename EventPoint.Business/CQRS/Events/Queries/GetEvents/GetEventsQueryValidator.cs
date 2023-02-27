using FluentValidation;

namespace EventPoint.Business.CQRS.Events.Queries.GetEvents
{
    public class GetEventsQueryValidator:AbstractValidator<GetEventsQuery>
    {
        public GetEventsQueryValidator()
        {
            RuleFor(x => x.PageSize).GreaterThan(0);
            RuleFor(x => x.PageNumber).GreaterThan(0);
        }
    }
}