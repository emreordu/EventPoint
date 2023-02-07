using EventPoint.Business.Modules.EventFavoriteCQRS.Commands.AddFavorite;
using EventPoint.Business.Modules.EventFavoriteCQRS.Queries.GetFavoritesByUser;
using EventPoint.Business.Modules.EventUserCQRS.Commands.AddParticipant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("participate-in-event")]
        public async Task<IActionResult> Participate(AddParticipantCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("add-favorite")]
        public async Task<IActionResult> AddFavorite(AddFavoriteCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("get-user-favorites/{id}")]
        public async Task<IActionResult> GetFavoritesOfUser(int id)
        {
            var response = await _mediator.Send(new GetFavoritesByUserQuery { UserId = id });
            return Ok(response);
        }
    }
}