using FluentValidation;

namespace EventPoint.Business.CQRS.EventManager.Commands.AddParticipant
{
    public class AddParticipantCommandValidator:AbstractValidator<AddParticipantCommand>
    {
        public AddParticipantCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EventId).NotEmpty().GreaterThan(0);
        }
    }
}