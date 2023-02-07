using EventPoint.Business.Modules.EventUserCQRS.Commands.AddParticipant;
using EventPoint.Business.Modules.EventUserCQRS.Queries.GetEventWithParticipants;
using EventPoint.Business.Modules.EventUserCQRS.Queries.GetParticipants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventManagerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-participants")]
        public async Task<IActionResult> GetParticipants()
        {
            var response = await _mediator.Send(new GetParticipantsQuery());
            return Ok(response);
        }
        [HttpGet("get-event-and-participants/{id}")]
        public async Task<IActionResult> GetEventAndParticipants(int id)
        {
            var response = await _mediator.Send(new GetEventWithParticipantsQuery { EventId = id });
            return Ok(response);
        }
        [HttpPost("add-participant")]
        public async Task<IActionResult> AddParticipantToEvent(AddParticipantCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        //[HttpPut("update-participant")]
        //public async Task<IActionResult> UpdateParticipant(UpdateParticipantCommand request)
        //{
        //    var response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}