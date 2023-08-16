using EventPoint.Business;
using EventPoint.Business.CQRS.Events.Commands.CreateEvent;
using EventPoint.Business.CQRS.Events.Commands.DeleteEvent;
using EventPoint.Business.CQRS.Events.Commands.UpdateEvent;
using EventPoint.Business.CQRS.Events.Queries.GetEventById;
using EventPoint.Business.CQRS.Events.Queries.GetEventByName;
using EventPoint.Business.CQRS.Events.Queries.GetEvents;
using EventPoint.Business.CQRS.Events.Queries.GetEventWithParticipants;
using EventPoint.Business.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class EventsController : BaseController
    {
        [HttpGet]
        public async Task<APIResponse<List<EventDTO>>> GetEvents(int pageSize = 50, int pageNumber = 1)
        {
            var result = await Mediator.Send(new GetEventsQuery { PageSize = pageSize, PageNumber = pageNumber });
            return ProduceResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<APIResponse<EventDTO>> GetEventById(int id)
        {
            var response = await Mediator.Send(new GetEventByIdQuery { Id = id });
            return ProduceResponse(response);
        }
        [HttpGet("name/{name}")]
        public async Task<APIResponse<EventDTO>> GetEventByName(string name)
        {
            var response = await Mediator.Send(new GetEventByNameQuery { Name = name });
            return ProduceResponse(response);
        }
        [HttpGet("{id}/participants")]
        public async Task<APIResponse<EventDTO>> GetEventWithParticipants(int id)
        {
            var response = await Mediator.Send(new GetEventWithParticipantsQuery { EventId = id });
            return ProduceResponse(response);
        }
        [HttpPost]
        [Authorize]
        public async Task<APIResponse<bool>> CreateEvent(CreateEventCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpDelete]
        [Authorize]
        public async Task<APIResponse<bool>> DeleteEvent(DeleteEventCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpPut]
        [Authorize]
        public async Task<APIResponse<EventDTO>> UpdateEvent(UpdateEventCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
    }
}