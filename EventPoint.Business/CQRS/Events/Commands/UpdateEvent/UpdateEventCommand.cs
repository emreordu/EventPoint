using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand:ICommand<EventDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParticipantLimit { get; set; }
        public DateTime EventDate { get; set; }
    }
}