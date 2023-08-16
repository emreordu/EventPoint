using EventPoint.Business.Behaviors;
using EventPoint.Business.Helpers;
using EventPoint.Business.Helpers.Models;
using EventPoint.Business.MappingProfile;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventPoint.Business.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehavior<,>));
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddScoped<IGetCurrentUser, GetCurrentUser>();
            return services;
        }
    }
}