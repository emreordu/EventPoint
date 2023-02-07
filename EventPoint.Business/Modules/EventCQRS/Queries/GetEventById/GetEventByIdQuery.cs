using EventPoint.Business.Dto;
using MediatR;

namespace EventPoint.Business.Modules.EventCQRS.Queries.GetEventById
{
    public class GetEventByIdQuery : IRequest<EventDTO>
    {
        public int Id { get; set; }
    }
}