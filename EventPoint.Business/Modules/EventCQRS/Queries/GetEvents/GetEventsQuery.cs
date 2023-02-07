using EventPoint.Business.Dto;
using MediatR;

namespace EventPoint.Business.Modules.EventCQRS.Queries.Requests
{
    public class GetEventsQuery : IRequest<List<EventDTO>>
    {
    }
}
