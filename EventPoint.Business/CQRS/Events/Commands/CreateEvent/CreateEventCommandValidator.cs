using FluentValidation;

namespace EventPoint.Business.CQRS.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator:AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.ParticipantLimit).GreaterThan(0);
            RuleFor(x => x.EventDate).NotEmpty().NotNull();
        }
    }
}