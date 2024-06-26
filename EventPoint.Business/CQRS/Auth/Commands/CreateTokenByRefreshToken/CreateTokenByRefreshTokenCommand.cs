﻿using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Auth.Commands.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommand: ICommand<TokenDTO>
    {
        public int UserId { get; set; }
    }
}