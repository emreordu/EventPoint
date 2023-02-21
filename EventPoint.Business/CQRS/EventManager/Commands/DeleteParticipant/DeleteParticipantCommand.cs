using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.EventManager.Commands.DeleteParticipant
{
    public class DeleteParticipantCommand:ICommand<bool>
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}