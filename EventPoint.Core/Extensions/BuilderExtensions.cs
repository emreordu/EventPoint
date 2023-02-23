using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventPoint.Core.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<RedisService>(sp =>
            {
                return new RedisService(configuration["Redis:Url"]);
            });
            return services;
        }
    }
}