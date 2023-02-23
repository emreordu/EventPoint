using EventPoint.Business.Dto;
using EventPoint.Core;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
using System.Text.Json;

namespace EventPoint.Business.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<UserRefreshToken> userRefreshTokenRepository;
        private const string userKey = "userCaches";
        private const string tokenKey = "tokenCaches";
        private readonly RedisService _redisService;
        private readonly IDatabase _cacheRepository;

        public AuthenticationHelper(ITokenHelper tokenService, UserManager<User> userManager,
            IUnitOfWork unitOfWork, RedisService redisService)
        {
            _tokenHelper = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            userRefreshTokenRepository = _unitOfWork.GetRepository<UserRefreshToken>();
            _redisService=redisService;
            _cacheRepository = _redisService.GetDb(0);
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
                throw new Exception("No user found.");
            }
            if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                throw new Exception("Username or password is wrong.");
            }
            var token = _tokenHelper.CreateToken(user);
            var refreshToken=await _cacheRepository.HashGetAsync(tokenKey,user.Id);
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
            await _cacheRepository.HashSetAsync(userKey, user.Id, JsonSerializer.Serialize(user.Email));
            await _cacheRepository.HashSetAsync(tokenKey, user.Id, JsonSerializer.Serialize(token.RefreshToken));
            await _cacheRepository.KeyExpireAsync(userKey,token.RefreshTokenExpiration);
            await _cacheRepository.KeyExpireAsync(tokenKey, token.RefreshTokenExpiration);
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
            await _cacheRepository.KeyDeleteAsync(userKey);
            await _cacheRepository.KeyDeleteAsync(tokenKey);
            await userRefreshTokenRepository.DeleteAsync(currentToken);

            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}