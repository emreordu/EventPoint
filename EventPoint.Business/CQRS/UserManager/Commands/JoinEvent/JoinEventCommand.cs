using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.UserManager.Commands.JoinEvent
{
    public class JoinEventCommand:ICommand<bool>
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}