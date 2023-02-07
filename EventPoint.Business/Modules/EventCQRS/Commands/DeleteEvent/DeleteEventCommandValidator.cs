using FluentValidation;

namespace EventPoint.Business.Modules.EventCQRS.Commands.DeleteEvent
{
    public class DeleteEventCommandValidator:AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}