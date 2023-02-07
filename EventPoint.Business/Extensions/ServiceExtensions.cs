using EventPoint.Business.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventPoint.Business.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
        //public static IServiceCollection AddValidator(this IServiceCollection services)
        //{
        //    services.AddValidator(createeve);
        //    return services;
        //}
    }
}