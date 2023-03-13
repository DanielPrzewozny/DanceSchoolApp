using DanceSchoolAPI.Common.Extensions;
using DanceSchoolAPI.Common.Modules;
using DanceSchoolAPI.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DanceSchoolAPI;

public class Startup
{
    const string CORS_POLICY = "CorsPolicy";

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddMvcCore();

        services.AddSwagger("v1", new OpenApiInfo { Title = "DanceSchoolApp", Version = "v1" }, false);

        services.AddOptions<HostingOptions>(Configuration);
        services.AddModule<RepositoriesModule>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HostingOptions hostingOptions)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
            app.UseHsts();

        if (hostingOptions.UseSwagger)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger("DanceSchoolApp", "doc/swagger");
        }

        app.UseRouting();
        app.UseCors(CORS_POLICY);
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
