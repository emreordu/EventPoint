using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EventPoint.Business.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization using bearer scheme.\n\n" +
                                 "Enter 'Bearer' [space] and then your token in below.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type= ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="oauth2",
                            Name="Bearer",
                            In= ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            return services;
        }
    }
}