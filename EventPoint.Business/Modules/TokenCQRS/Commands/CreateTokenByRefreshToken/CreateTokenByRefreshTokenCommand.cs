using EventPoint.DataAccess.IdentityServer;
using EventPoint.DataAccess.IdentityServer.Dto;
using MediatR;

namespace EventPoint.Business.Modules.TokenCQRS.Commands.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommand: IRequest<ResponseDTO<TokenDTO>>
    {
        public string RefreshToken { get; set; }
    }
}