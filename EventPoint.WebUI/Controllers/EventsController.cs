using EventPoint.Business.Modules.EventCQRS.Commands.CreateEvent;
using EventPoint.Business.Modules.EventCQRS.Commands.DeleteEvent;
using EventPoint.Business.Modules.EventCQRS.Commands.UpdateEvent;
using EventPoint.Business.Modules.EventCQRS.Queries.GetEventById;
using EventPoint.Business.Modules.EventCQRS.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;
        //protected APIResponse _response;
        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
            //this._response = new();
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetEventsQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetEventByIdQuery { Id = id });
            return Ok(response);
        }
        [HttpPost("create-event")]
        public async Task<IActionResult> CreateEvent(CreateEventCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("delete-event")]
        public async Task<IActionResult> DeleteEvent(DeleteEventCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("update-event")]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}