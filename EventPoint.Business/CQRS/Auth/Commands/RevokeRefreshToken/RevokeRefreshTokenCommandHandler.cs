using EventPoint.Business.Mediator;
using EventPoint.Core;
using StackExchange.Redis;

namespace EventPoint.Business.CQRS.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler : ICommandHandler<RevokeRefreshTokenCommand, bool>
    {
        private readonly RedisService _redisService;
        private readonly IDatabase _cacheRepository;
        private string userKey = "userCache";
        private string tokenKey = "tokenCache";
        public RevokeRefreshTokenCommandHandler(RedisService redisService)
        {
            _redisService = redisService;
            _cacheRepository = _redisService.GetDb(0);
        }
        public async Task<bool> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            tokenKey += request.UserId.ToString();
            userKey += request.UserId.ToString();
            var currentToken = await _cacheRepository.StringGetAsync(tokenKey);
            if (currentToken.IsNullOrEmpty)
            {
                throw new Exception("Refreh Token not found.");
            }
            await _cacheRepository.KeyDeleteAsync(tokenKey);
            await _cacheRepository.KeyDeleteAsync(userKey);
            return true;
        }
    }
}