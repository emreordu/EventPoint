using EventPoint.Business.Modules.UserCQRS.Commands.CreateUser;
using EventPoint.Business.Modules.UserCQRS.Commands.DeleteUser;
using EventPoint.Business.Modules.UserCQRS.Commands.UpdateUser;
using EventPoint.Business.Modules.UserCQRS.Queries.GetUserById;
using EventPoint.Business.Modules.UserCQRS.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _mediator.Send(new GetUsersQuery());
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery { Id = id });
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(CreateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}