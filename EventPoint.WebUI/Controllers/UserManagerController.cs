using EventPoint.Business;
using EventPoint.Business.CQRS.UserManager.Commands.AddFavorite;
using EventPoint.Business.CQRS.UserManager.Commands.AddUserRole;
using EventPoint.Business.CQRS.UserManager.Commands.DeleteFavorite;
using EventPoint.Business.CQRS.UserManager.Commands.DeleteUserRole;
using EventPoint.Business.CQRS.UserManager.Commands.JoinEvent;
using EventPoint.Business.CQRS.UserManager.Commands.LeaveEvent;
using EventPoint.Business.CQRS.UserManager.Queries.GetFavoritesByUser;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class UserManagerController : BaseController
    {
        public UserManagerController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("event")]
        public async Task<APIResponse<bool>> JoinEvent(JoinEventCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpPost("favorite")]
        public async Task<APIResponse<bool>> AddFavorite(AddFavoriteCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpGet("favorite/{id}")]
        public async Task<APIResponse<UserDTO>> GetFavoritesOfUser(int id)
        {
            var response = await _mediator.Send(new GetFavoritesByUserQuery { UserId = id });
            return ProduceResponse(response);
        }
        [HttpDelete("favorite")]
        public async Task<APIResponse<bool>> DeleteFavorite(DeleteFavoriteCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpPost("role")]
        public async Task<APIResponse<bool>> AddUserRole(AddUserRoleCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpDelete("role")]
        public async Task<APIResponse<bool>> DeleteUserRole(DeleteUserRoleCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpDelete("event")]
        public async Task<APIResponse<bool>> LeaveEvent(LeaveEventCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
    }
}