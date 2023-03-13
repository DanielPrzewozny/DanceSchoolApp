using Microsoft.AspNetCore.Builder;

namespace DanceSchoolAPI.Common.Extensions;

public static class AppBuilderExtensions
{
    public static IApplicationBuilder UseSwagger(this IApplicationBuilder builder, string name, string route)
    => builder.UseSwagger(c => c.RouteTemplate = $"{route}/{{documentname}}/swagger.json")
        .UseSwaggerUI(c =>
        {
            c.RoutePrefix = route;
            c.SwaggerEndpoint($"/{route}/v1/swagger.json", "DanceSchoolAPI");
        });
}
