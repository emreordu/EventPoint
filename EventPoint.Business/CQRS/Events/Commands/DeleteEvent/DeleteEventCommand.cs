using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}