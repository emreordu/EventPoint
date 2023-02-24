using EventPoint.Business.Dto;

namespace EventPoint.Business.Helpers
{
    public interface IAuthenticationHelper
    {
        Task<TokenDTO> CreateTokenAsync(LoginDTO loginDTO, CancellationToken cancellationToken);
        Task<TokenDTO> CreateTokenByRefreshToken(int userId, CancellationToken cancellationToken);
        Task<bool> RevokeRefreshToken(int userId, CancellationToken cancellationToken);
    }
}