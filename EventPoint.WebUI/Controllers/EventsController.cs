using EventPoint.Business;
using EventPoint.Business.CQRS.Events.Commands.CreateEvent;
using EventPoint.Business.CQRS.Events.Commands.DeleteEvent;
using EventPoint.Business.CQRS.Events.Commands.UpdateEvent;
using EventPoint.Business.CQRS.Events.Queries.GetEventById;
using EventPoint.Business.CQRS.Events.Queries.GetEvents;
using EventPoint.Business.CQRS.Events.Queries.GetEventWithParticipants;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class EventsController : BaseController
    {
        public EventsController(IMediator mediator):base(mediator) 
        {
        }
        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<APIResponse<List<EventDTO>>> GetEvents(int pageSize = 50, int pageNumber = 1)
        {
            var result = await _mediator.Send(new GetEventsQuery { PageSize = pageSize, PageNumber = pageNumber });
            return ProduceResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<APIResponse<EventDTO>> GetEventById(int id)
        {
            var response = await _mediator.Send(new GetEventByIdQuery { Id = id });
            return ProduceResponse(response);
        }
        [HttpGet("{id}/participants")]
        public async Task<APIResponse<EventDTO>> GetEventWithParticipants(int id)
        {
            var response = await _mediator.Send(new GetEventWithParticipantsQuery { EventId = id });
            return ProduceResponse(response);
        }
        [HttpPost]
        public async Task<APIResponse<bool>> CreateEvent(CreateEventCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpDelete]
        public async Task<APIResponse<bool>> DeleteEvent(DeleteEventCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpPut]
        public async Task<APIResponse<EventDTO>> UpdateEvent(UpdateEventCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
    }
}