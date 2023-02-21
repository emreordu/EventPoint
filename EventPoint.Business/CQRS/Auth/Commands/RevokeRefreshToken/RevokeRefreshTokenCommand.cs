using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand : ICommand<bool>
    {
        public string RefreshToken { get; set; }
    }
}