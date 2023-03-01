using EventPoint.Business;
using EventPoint.Business.CQRS.Auth.Commands.CreateTokenByRefreshToken;
using EventPoint.Business.CQRS.Auth.Commands.Login;
using EventPoint.Business.CQRS.Auth.Commands.RevokeRefreshToken;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("login")]
        public async Task<APIResponse<TokenDTO>> Login(LoginCommand request)
        {
            var result = await _mediator.Send(request);
            return ProduceResponse(result);
        }
        [HttpPost("logout")]
        public async Task<APIResponse<bool>> Logout(RevokeRefreshTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return ProduceResponse(result);
        }
        [HttpPost("token")]
        public async Task<APIResponse<TokenDTO>> CreateTokenByRefreshToken(CreateTokenByRefreshTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return ProduceResponse(result);
        }
    }
}