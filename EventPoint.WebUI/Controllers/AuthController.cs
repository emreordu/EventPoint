﻿using EventPoint.Business;
using EventPoint.Business.CQRS.Auth.Commands.CreateToken;
using EventPoint.Business.CQRS.Auth.Commands.CreateTokenByRefreshToken;
using EventPoint.Business.CQRS.Auth.Commands.RevokeRefreshToken;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<APIResponse<TokenDTO>> Login(CreateTokenCommand request)
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
        [HttpPost("create-token-by-refresh-token")]
        public async Task<APIResponse<TokenDTO>> CreateTokenByRefreshToken(CreateTokenByRefreshTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return ProduceResponse(result);
        }
    }
}