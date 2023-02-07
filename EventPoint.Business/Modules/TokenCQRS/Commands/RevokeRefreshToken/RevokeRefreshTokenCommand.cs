using MediatR;

namespace EventPoint.Business.Modules.TokenCQRS.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand : IRequest<bool>
    {
        public string RefreshToken { get; set; }
    }
}