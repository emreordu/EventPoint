using FluentValidation;

namespace EventPoint.Business.CQRS.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandValidator:AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}