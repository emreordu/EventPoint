using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Events.Queries.GetEventById
{
    public class GetEventByIdQuery : IQuery<EventDTO>
    {
        public int Id { get; set; }
    }
}