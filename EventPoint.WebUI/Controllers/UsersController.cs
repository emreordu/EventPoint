using EventPoint.Business;
using EventPoint.Business.CQRS.Users.Commands.CreateUser;
using EventPoint.Business.CQRS.Users.Commands.DeleteUser;
using EventPoint.Business.CQRS.Users.Commands.UpdateUser;
using EventPoint.Business.CQRS.Users.Queries.GetUserById;
using EventPoint.Business.CQRS.Users.Queries.GetUsers;
using EventPoint.Business.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<APIResponse<List<UserDTO>>> GetUsers(int pageSize = 50, int pageNumber = 1)
        {
            var response = await Mediator.Send(new GetUsersQuery { PageSize = pageSize, PageNumber = pageNumber });
            return ProduceResponse(response);
        }
        [HttpGet("{id}")]
        public async Task<APIResponse<UserDTO>> GetUserById(int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery { Id = id });
            return ProduceResponse(response);
        }
        [HttpPost]
        public async Task<APIResponse<bool>> CreateUser(CreateUserCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpPut]
        [Authorize]
        public async Task<APIResponse<UserDTO>> UpdateUser(UpdateUserCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpDelete]
        [Authorize]
        public async Task<APIResponse<bool>> DeleteUser(DeleteUserCommand request)
        {
            var response = await Mediator.Send(request);
            return ProduceResponse(response);
        }
    }
}