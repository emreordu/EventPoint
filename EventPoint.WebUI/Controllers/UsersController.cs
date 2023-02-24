using EventPoint.Business;
using EventPoint.Business.CQRS.Users.Commands.CreateUser;
using EventPoint.Business.CQRS.Users.Commands.DeleteUser;
using EventPoint.Business.CQRS.Users.Commands.UpdateUser;
using EventPoint.Business.CQRS.Users.Queries.GetUserById;
using EventPoint.Business.CQRS.Users.Queries.GetUsers;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet()]
        public async Task<APIResponse<List<UserDTO>>> GetUsers(int pageSize = 3, int pageNumber = 1)
        {
            var response = await _mediator.Send(new GetUsersQuery { PageSize = pageSize, PageNumber = pageNumber });
            return ProduceResponse(response);
        }
        [HttpGet("{id}")]
        public async Task<APIResponse<UserDTO>> GetUserById(int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery { Id = id });
            return ProduceResponse(response);
        }
        [HttpPost]
        public async Task<APIResponse<bool>> CreateUser(CreateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpPut]
        public async Task<APIResponse<UserDTO>> UpdateUser(UpdateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpDelete]
        public async Task<APIResponse<bool>> DeleteUser(DeleteUserCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
    }
}