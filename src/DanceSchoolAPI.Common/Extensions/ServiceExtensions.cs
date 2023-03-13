using DanceSchoolAPI.Common.Modules;
using DanceSchoolAPI.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DanceSchoolAPI.Common.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddModule<T>(this IServiceCollection services)
        where T : IModule, new()
    {
        new T().Load(services);

        return services;
    }

    public static TOptions AddOptions<TOptions>(this IServiceCollection services, IConfiguration configuration)
        where TOptions : class, IOptions, new()
    {
        var options = configuration.GetOptions<TOptions>();
        services.Configure<TOptions>(configuration.GetSection(options.SectionKey));
        services.AddSingleton(options);
        return options;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services, string name, OpenApiInfo info, bool useJWT)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(name, info);
            if (useJWT)
            {
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT header",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                    }
                );
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme,
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            },
                            new List<string>()
                        },
                    }
                );
            }
        });
        return services;
    }
}
