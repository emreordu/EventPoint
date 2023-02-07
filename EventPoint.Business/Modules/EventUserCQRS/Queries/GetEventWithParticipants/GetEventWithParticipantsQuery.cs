using EventPoint.Business.Dto;
using MediatR;

namespace EventPoint.Business.Modules.EventUserCQRS.Queries.GetEventWithParticipants
{
    public class GetEventWithParticipantsQuery : IRequest<EventDTO>
    {
        public int EventId { get; set; }
    }
}