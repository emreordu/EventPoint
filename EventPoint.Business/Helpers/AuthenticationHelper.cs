using EventPoint.Business.Dto;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace EventPoint.Business.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<UserRefreshToken> userRefreshTokenRepository;
        public AuthenticationHelper(ITokenHelper tokenService, UserManager<User> userManager,
            IUnitOfWork unitOfWork)
        {
            _tokenHelper = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            userRefreshTokenRepository = _unitOfWork.GetRepository<UserRefreshToken>();
        }
        public async Task<TokenDTO> CreateTokenAsync(LoginDTO loginDTO, CancellationToken cancellationToken)
        {
            if (loginDTO == null)
            {
                throw new ArgumentNullException(nameof(loginDTO));
            }
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                throw new Exception();
            }
            if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                throw new Exception("Username or password is wrong.");
            }
            var token = _tokenHelper.CreateToken(user);
            var userRefreshToken = await userRefreshTokenRepository.GetFirstOrDefaultAsync(x => x.UserId == user.Id.ToString());

            if (userRefreshToken == null)
            {
                await userRefreshTokenRepository.CreateAsync(new UserRefreshToken
                {
                    UserId = user.Id.ToString(),
                    Code = token.RefreshToken,
                    Expiration = token.RefreshTokenExpiration
                });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
                await userRefreshTokenRepository.UpdateAsync(userRefreshToken);
            }

            await _unitOfWork.CommitAsync(cancellationToken);
            return token;
        }
        public async Task<TokenDTO> CreateTokenByRefreshToken(string refreshToken, CancellationToken cancellationToken)
        {
            var token = await userRefreshTokenRepository.GetFirstOrDefaultAsync(x => x.Code == refreshToken);
            if (token == null)
            {
                throw new Exception("Refresh Token not found.");
            }

            var user = await _userManager.FindByIdAsync(token.UserId);
            if (user == null)
            {
                throw new Exception("UserId not found.");
            }
            var accessToken = _tokenHelper.CreateToken(user);
            token.Code = accessToken.RefreshToken;
            token.Expiration = accessToken.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync(cancellationToken);

            return accessToken;
        }
        public async Task<bool> RevokeRefreshToken(string refreshToken, CancellationToken cancellationToken)
        {
            var currentToken = await userRefreshTokenRepository.GetFirstOrDefaultAsync(x => x.Code == refreshToken);

            if (currentToken == null)
            {
                throw new Exception("Refreh Token not found.");
            }
            await userRefreshTokenRepository.DeleteAsync(currentToken);

            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}