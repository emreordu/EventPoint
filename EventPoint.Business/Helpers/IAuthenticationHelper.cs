using EventPoint.Business.Dto;

namespace EventPoint.Business.Helpers
{
    public interface IAuthenticationHelper
    {
        Task<TokenDTO> CreateTokenAsync(LoginDTO loginDTO, CancellationToken cancellationToken);
        Task<TokenDTO> CreateTokenByRefreshToken(string refreshToken, CancellationToken cancellationToken);
        Task<bool> RevokeRefreshToken(string refreshToken, CancellationToken cancellationToken);
    }
}