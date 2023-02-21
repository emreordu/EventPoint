using FluentValidation;

namespace EventPoint.Business.CQRS.EventManager.Commands.DeleteParticipant
{
    public class DeleteParticipantCommandValidator: AbstractValidator<DeleteParticipantCommand>
    {
        public DeleteParticipantCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EventId).NotEmpty().GreaterThan(0);
        }
    }
}