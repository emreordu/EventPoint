using FluentValidation;

namespace EventPoint.Business.CQRS.UserManager.Commands.JoinEvent
{
    public class JoinEventCommandValidator:AbstractValidator<JoinEventCommand>
    {
        public JoinEventCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EventId).NotEmpty().GreaterThan(0);
        }
    }
}