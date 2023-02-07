using FluentValidation;

namespace EventPoint.Business.Modules.EventCQRS.Queries.GetEventById
{
    public class GetEventByIdQueryValidator:AbstractValidator<GetEventByIdQuery>
    {
        public GetEventByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}