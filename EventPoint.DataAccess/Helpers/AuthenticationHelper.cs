using EventPoint.DataAccess.IdentityServer;
using EventPoint.DataAccess.IdentityServer.Dto;
using EventPoint.DataAccess.IdentityServer.Models;
using EventPoint.DataAccess.Repository.Abstract;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventPoint.DataAccess.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserRefreshToken> _userRefreshTokenService;
        public AuthenticationHelper(ITokenHelper tokenService, UserManager<User> userManager,
            IUnitOfWork unitOfWork, IRepository<UserRefreshToken> userRefreshTokenService)
        {
            _tokenHelper = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;
        }
        public async Task<ResponseDTO<TokenDTO>> CreateTokenAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                throw new ArgumentNullException(nameof(loginDTO));
            }
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return ResponseDTO<TokenDTO>.Fail("Email or password is wrong.", 400, true);
            }
            if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                return ResponseDTO<TokenDTO>.Fail("Email or password is wrong.", 400, true);
            }
            var token = _tokenHelper.CreateToken(user);
            var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == user.Id.ToString()).SingleOrDefaultAsync();
            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.CreateAsync(new UserRefreshToken
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
                _userRefreshTokenService.UpdateAsync(userRefreshToken);
            }

            await _unitOfWork.CommitAsync();
            return ResponseDTO<TokenDTO>.Success(token, 200);
        }
        public async Task<ResponseDTO<TokenDTO>> CreateTokenByRefreshToken(string refreshToken)
        {
            var token = await _userRefreshTokenService.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (token == null)
            {
                return ResponseDTO<TokenDTO>.Fail("Refresh Token not found.", 404, true);
            }

            var user = await _userManager.FindByIdAsync(token.UserId);
            if (user == null)
            {
                return ResponseDTO<TokenDTO>.Fail("UserId not found.", 404, true);
            }
            var accessToken = _tokenHelper.CreateToken(user);
            token.Code = accessToken.RefreshToken;
            token.Expiration = accessToken.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync();

            return ResponseDTO<TokenDTO>.Success(accessToken, 200);
        }
        public async Task<ResponseDTO<NoDataDTO>> RevokeRefreshToken(string refreshToken)
        {
            var currentToken = await _userRefreshTokenService.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (currentToken == null)
            {
                return ResponseDTO<NoDataDTO>.Fail("Refreh Token not found.", 404, true);
            }
            await _userRefreshTokenService.DeleteAsync(currentToken);

            await _unitOfWork.CommitAsync();
            return ResponseDTO<NoDataDTO>.Success(200);
        }
    }
}