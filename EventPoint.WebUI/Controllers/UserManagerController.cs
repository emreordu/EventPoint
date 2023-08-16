using EventPoint.Business;
using EventPoint.Business.CQRS.UserManager.Commands.AddFavorite;
using EventPoint.Business.CQRS.UserManager.Commands.AddUserRole;
using EventPoint.Business.CQRS.UserManager.Commands.DeleteFavorite;
using EventPoint.Business.CQRS.UserManager.Commands.DeleteUserRole;
using EventPoint.Business.CQRS.UserManager.Commands.JoinEvent;
using EventPoint.Business.CQRS.UserManager.Commands.LeaveEvent;
using EventPoint.Business.CQRS.UserManager.Queries.GetFavoritesByUser;
using EventPoint.Business.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class UserManagerController : BaseController
    {
        [HttpPost("event")]
        [Authorize]
        public async Task<APIResponse<bool>> JoinEvent(JoinEventCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpPost("favorite")]
        [Authorize]
        public async Task<APIResponse<bool>> AddFavorite(AddFavoriteCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpGet("favorite/{id}")]
        public async Task<APIResponse<UserDTO>> GetFavoritesOfUser(int id)
        {
            var response = await Mediator.Send(new GetFavoritesByUserQuery { UserId = id });
            return ProduceResponse(response);
        }
        [HttpDelete("favorite")]
        [Authorize]
        public async Task<APIResponse<bool>> DeleteFavorite(DeleteFavoriteCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpPost("role")]
        [Authorize]
        public async Task<APIResponse<bool>> AddUserRole(AddUserRoleCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpDelete("role")]
        [Authorize]
        public async Task<APIResponse<bool>> DeleteUserRole(DeleteUserRoleCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpDelete("event")]
        [Authorize]
        public async Task<APIResponse<bool>> LeaveEvent(LeaveEventCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
    }
}