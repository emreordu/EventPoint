using EventPoint.DataAccess.Data;
using EventPoint.DataAccess.Interceptor;
using EventPoint.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventPoint.DataAccess.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddDataAccesLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultSQLConnection")).
                AddInterceptors(new LogSQLQueryInterceptor());
                option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            return services;
        }
    }
}