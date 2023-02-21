using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Events.Commands.CreateEvent
{
    public class CreateEventCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int ParticipantLimit { get; set; }
        public DateTime? EventDate { get; set; }
    }
}