using EventPoint.Business.Dto;
using EventPoint.Business.Helpers;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Auth.Commands.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommandHandler : ICommandHandler<CreateTokenByRefreshTokenCommand, TokenDTO>
    {
        private readonly IAuthenticationHelper _authenticationHelper;
        public CreateTokenByRefreshTokenCommandHandler(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }
        public async Task<TokenDTO> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationHelper.CreateTokenByRefreshToken(request.RefreshToken,cancellationToken);
            return result;
        }
    }
}