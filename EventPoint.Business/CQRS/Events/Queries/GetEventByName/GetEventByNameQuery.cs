using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Events.Queries.GetEventByName
{
    public class GetEventByNameQuery : IQuery<EventDTO>
    {
        public string Name { get; set; }
    }
}