using EventPoint.DataAccess.IdentityServer;
using EventPoint.DataAccess.IdentityServer.Dto;
using MediatR;

namespace EventPoint.Business.Modules.TokenCQRS.Commands.CreateToken
{
    public class CreateTokenCommand:IRequest<ResponseDTO<TokenDTO>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}