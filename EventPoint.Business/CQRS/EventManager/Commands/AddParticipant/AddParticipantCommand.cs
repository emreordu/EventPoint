using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.EventManager.Commands.AddParticipant
{
    public class AddParticipantCommand:ICommand<bool>
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}