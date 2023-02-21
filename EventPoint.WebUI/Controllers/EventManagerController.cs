using EventPoint.Business;
using EventPoint.Business.CQRS.EventManager.Commands.AddParticipant;
using EventPoint.Business.CQRS.EventManager.Commands.DeleteParticipant;
using EventPoint.Business.CQRS.EventManager.Queries.GetEventWithParticipants;
using EventPoint.Business.CQRS.EventManager.Queries.GetParticipants;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class EventManagerController : BaseController
    {
        private readonly IMediator _mediator;
        public EventManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-event-and-participants")]
        public async Task<APIResponse<List<ParticipateEventDTO>>> GetParticipants(int pageSize = 10, int pageNumber = 1)
        {
            var response = await _mediator.Send(new GetParticipantsQuery { PageSize = pageSize, PageNumber = pageNumber });
            return ProduceResponse(response);
        }
        [HttpGet("get-event-and-participants/{id}")]
        public async Task<APIResponse<EventDTO>> GetEventAndParticipants(int id)
        {
            var response = await _mediator.Send(new GetEventWithParticipantsQuery { EventId = id });
            return ProduceResponse(response);
        }
        [HttpPost("add-participant")]
        public async Task<APIResponse<bool>> AddParticipantToEvent(AddParticipantCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpDelete("delete-participant")]
        public async Task<APIResponse<bool>> DeleteParticipant(DeleteParticipantCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
    }
}