using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.UserManager.Commands.LeaveEvent
{
    public class LeaveEventCommand:ICommand<bool>
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}