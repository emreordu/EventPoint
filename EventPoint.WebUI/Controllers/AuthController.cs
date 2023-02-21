using EventPoint.Business;
using EventPoint.Business.CQRS.Auth.Commands.CreateToken;
using EventPoint.Business.CQRS.Auth.Commands.CreateTokenByRefreshToken;
using EventPoint.Business.CQRS.Auth.Commands.RevokeRefreshToken;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventPoint.WebUI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<APIResponse<TokenDTO>> CreateToken(CreateTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return new APIResponse<TokenDTO> { Result = result, IsSuccess = true, StatusCode = HttpStatusCode.OK };
        }
        [HttpPost("revoke-refresh-token")]
        public async Task<APIResponse<bool>> RevokeRefreshToken(RevokeRefreshTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return new APIResponse<bool> { Result = result, IsSuccess = true, StatusCode = HttpStatusCode.OK };
        }
        [HttpPost("create-token-by-refresh-token")]
        public async Task<APIResponse<TokenDTO>> CreateTokenByRefreshToken(CreateTokenByRefreshTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return new APIResponse<TokenDTO> { Result = result, IsSuccess = true, StatusCode = HttpStatusCode.OK };
        }
    }
}