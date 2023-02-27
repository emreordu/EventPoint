using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Events.Queries.GetEventWithParticipants
{
    public class GetEventWithParticipantsQuery : IQuery<EventDTO>
    {
        public int EventId { get; set; }
    }
}