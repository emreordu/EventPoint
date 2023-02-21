using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.EventManager.Queries.GetParticipants
{
    public class GetParticipantsQuery : IQuery<List<ParticipateEventDTO>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}