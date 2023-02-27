using FluentValidation;

namespace EventPoint.Business.CQRS.UserManager.Commands.LeaveEvent
{
    public class LeaveEventCommandValidator : AbstractValidator<LeaveEventCommand>
    {
        public LeaveEventCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EventId).NotEmpty().GreaterThan(0);
        }
    }
}