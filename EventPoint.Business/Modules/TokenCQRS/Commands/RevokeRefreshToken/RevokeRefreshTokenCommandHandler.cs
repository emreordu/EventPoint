using EventPoint.DataAccess.Helpers;
using MediatR;

namespace EventPoint.Business.Modules.TokenCQRS.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler : IRequestHandler<RevokeRefreshTokenCommand, bool>
    {
        private readonly IAuthenticationHelper _authenticationHelper;
        public RevokeRefreshTokenCommandHandler(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }
        public async Task<bool> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            await _authenticationHelper.RevokeRefreshToken(request.RefreshToken);
            return true;
        }
    }
}