using EventPoint.DataAccess.Helpers;
using EventPoint.DataAccess.IdentityServer;
using EventPoint.DataAccess.IdentityServer.Dto;
using MediatR;

namespace EventPoint.Business.Modules.TokenCQRS.Commands.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommandHandler : IRequestHandler<CreateTokenByRefreshTokenCommand, ResponseDTO<TokenDTO>>
    {
        private readonly IAuthenticationHelper _authenticationHelper;
        public CreateTokenByRefreshTokenCommandHandler(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }
        public async Task<ResponseDTO<TokenDTO>> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationHelper.CreateTokenByRefreshToken(request.RefreshToken);
            return result;
        }
    }
}