using EventPoint.Business;
using EventPoint.Business.CQRS.Events.Commands.CreateEvent;
using EventPoint.Business.CQRS.Events.Commands.DeleteEvent;
using EventPoint.Business.CQRS.Events.Commands.UpdateEvent;
using EventPoint.Business.CQRS.Events.Queries.GetEventById;
using EventPoint.Business.CQRS.Events.Queries.GetEvents;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventPoint.WebUI.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IMediator _mediator;
        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<APIResponse<List<EventDTO>>> GetEvents(int pageSize=3, int pageNumber=1)
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