using EventPoint.Business;
using EventPoint.Business.CQRS.Users.Commands.CreateUser;
using EventPoint.Business.CQRS.Users.Commands.DeleteUser;
using EventPoint.Business.CQRS.Users.Commands.UpdateUser;
using EventPoint.Business.CQRS.Users.Queries.GetUserById;
using EventPoint.Business.CQRS.Users.Queries.GetUsers;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventPoint.WebUI.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        public async Task<APIResponse<List<UserDTO>>> GetUsers()
        {
            var response = await _mediator.Send(new GetUsersQuery());
            return new APIResponse<List<UserDTO>> { Result = response, IsSuccess = true, StatusCode = HttpStatusCode.OK };
        }
        [HttpGet("{id}")]
        public async Task<APIResponse<UserDTO>> GetUserById(int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery { Id = id });
            return new APIResponse<UserDTO> { Result=response,IsSuccess=true, StatusCode = HttpStatusCode.OK };
        }
        [HttpPost]
        public async Task<APIResponse<bool>> CreateUser(CreateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return new APIResponse<bool> { Result=response, IsSuccess=true,StatusCode = HttpStatusCode.OK };
        }
        [HttpPut]
        public async Task<APIResponse<UserDTO>> UpdateUser(UpdateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return new APIResponse<UserDTO> { Result=response,IsSuccess=true,StatusCode = HttpStatusCode.OK };
        }
        [HttpDelete]
        public async Task<APIResponse<bool>> DeleteUser(DeleteUserCommand request)
        {
            var response = await _mediator.Send(request);
            return new APIResponse<bool> { Result = response, IsSuccess = true, StatusCode = HttpStatusCode.OK };
        }
    }
}