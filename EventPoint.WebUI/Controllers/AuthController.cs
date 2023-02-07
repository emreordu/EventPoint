using EventPoint.Business.Modules.TokenCQRS.Commands.CreateToken;
using EventPoint.Business.Modules.TokenCQRS.Commands.CreateTokenByRefreshToken;
using EventPoint.Business.Modules.TokenCQRS.Commands.RevokeRefreshToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> CreateToken(CreateTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshToken(RevokeRefreshTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("create-token-by-refresh-token")]
        public async Task<IActionResult> CreateTokenByRefreshToken(CreateTokenByRefreshTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}