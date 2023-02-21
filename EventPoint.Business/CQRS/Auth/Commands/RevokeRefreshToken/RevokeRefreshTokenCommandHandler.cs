using EventPoint.Business.Helpers;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler : ICommandHandler<RevokeRefreshTokenCommand, bool>
    {
        private readonly IAuthenticationHelper _authenticationHelper;
        public RevokeRefreshTokenCommandHandler(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }
        public async Task<bool> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            await _authenticationHelper.RevokeRefreshToken(request.RefreshToken,cancellationToken);
            return true;
        }
    }
}