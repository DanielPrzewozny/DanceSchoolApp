using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace DanceSchoolAPI.Extensions;

public static class AppBuilderExtensions
{
    public static IApplicationBuilder UseSwagger(this IApplicationBuilder builder, string name, string route)
    => builder.UseSwagger(c =>
    {
        c.RouteTemplate = $"{route}/{{documentname}}/swagger.json";
    })
    .UseSwaggerUI(c =>
    {
        c.RoutePrefix = route;
        c.SwaggerEndpoint($"/{route}/v1/swagger.json", "DanceSchoolAPI");
    });
}
