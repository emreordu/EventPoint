using FluentValidation;

namespace EventPoint.Business.CQRS.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator:AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.ParticipantLimit).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EventDate).NotEmpty().NotNull();
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}