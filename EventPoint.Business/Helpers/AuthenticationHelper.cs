using EventPoint.Business.Dto;
using EventPoint.Core;
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
        private readonly RedisService _redisService;
        private readonly IDatabase _cacheRepository;
        private string userKey = "userCache";
        private string tokenKey = "tokenCache";

        public AuthenticationHelper(ITokenHelper tokenService, UserManager<User> userManager, RedisService redisService)
        {
            _tokenHelper = tokenService;
            _userManager = userManager;
            _redisService = redisService;
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
            userKey += user.Id.ToString();
            tokenKey += user.Id.ToString();

            var token = _tokenHelper.CreateToken(user);

            await _cacheRepository.HashSetAsync(userKey, user.Id, JsonSerializer.Serialize(user.Email));
            await _cacheRepository.HashSetAsync(tokenKey, user.Id, JsonSerializer.Serialize(token.RefreshToken));

            //convert to set. remove keyexpire.
            await _cacheRepository.KeyExpireAsync(userKey, token.RefreshTokenExpiration);
            await _cacheRepository.KeyExpireAsync(tokenKey, token.RefreshTokenExpiration);
            return token;
        }
        public async Task<TokenDTO> CreateTokenByRefreshToken(int userId, CancellationToken cancellationToken)
        {
            tokenKey += userId.ToString();
            var token = await _cacheRepository.HashGetAsync(tokenKey, userId);
            if (token.IsNullOrEmpty)
            {
                throw new Exception("Refresh Token not found.");
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("UserId not found.");
            }
            var accessToken = _tokenHelper.CreateToken(user);
            await _cacheRepository.HashSetAsync(tokenKey, user.Id, JsonSerializer.Serialize(accessToken.RefreshToken));
            await _cacheRepository.KeyExpireAsync(tokenKey, accessToken.RefreshTokenExpiration);
            return accessToken;
        }
        public async Task<bool> RevokeRefreshToken(int userId, CancellationToken cancellationToken)
        {
            userKey += userId.ToString();
            tokenKey += userId.ToString();
            var currentToken = await _cacheRepository.HashGetAsync(tokenKey, userId);
            if (currentToken.IsNullOrEmpty)
            {
                throw new Exception("Refreh Token not found.");
            }
            await _cacheRepository.KeyDeleteAsync(userKey);
            await _cacheRepository.KeyDeleteAsync(tokenKey);
            return true;
        }
    }
}