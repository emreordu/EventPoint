using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Events.Queries.GetEvents
{
    public class GetEventsQuery : IQuery<List<EventDTO>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}