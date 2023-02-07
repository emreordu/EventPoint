using EventPoint.Business.Dto;
using MediatR;

namespace EventPoint.Business.Modules.EventCQRS.Commands.UpdateEvent
{
    public class UpdateEventCommand:IRequest<EventDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParticipantLimit { get; set; }
        public DateTime? EventDate { get; set; }
    }
}