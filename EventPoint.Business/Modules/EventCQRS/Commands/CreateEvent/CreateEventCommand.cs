using EventPoint.Business.Dto;
using MediatR;

namespace EventPoint.Business.Modules.EventCQRS.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int ParticipantLimit { get; set; }
        public DateTime? EventDate { get; set; }
    }
}