using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using DanceSchoolAPI.Models.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace DanceSchoolAPI;

public class Program
{
    public static void Main(string[] args)
    {
        string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var logger = NLogBuilder.ConfigureNLog($"NLog.{(string.IsNullOrEmpty(env) ? string.Empty : $"{env}.")}config").GetCurrentClassLogger();

        try
        {
            logger.Info("DanceSchoolApp Starting");
            ThreadPool.SetMinThreads(200, 200);
            CreateWebHostBuilder(args, logger).Build().Run();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message, "Stopped program because of exception");
            logger.Trace(ex.StackTrace);
        }
        finally
        {
            NLog.LogManager.Shutdown();
        }
    }

    public static IHostBuilder CreateWebHostBuilder(string[] args, Logger logger)
        => Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((host, config) =>
            {
                config.AddJsonFile("appsettings.json", true, false)
                    .AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json", true, false);
                config.AddEnvironmentVariables("DANCESCHOOLPI_");
            })
            .UseWindowsService()
            .UseSystemd()
            .ConfigureWebHostDefaults(webBuilder =>
                webBuilder
                    .UseStartup<Startup>()
                    .UseKestrel((context, options) =>
                    {
                        var hostingOptions = options.ApplicationServices.GetService(typeof(HostingOptions)) as HostingOptions ?? new HostingOptions();
                        if (hostingOptions.UseInsecure)
                        {
                            logger.Info("Use http");
                            options.ListenAnyIP(hostingOptions.InsecurePort);
                        }

                        if (hostingOptions.UseSecure)
                        {
                            logger.Info("Use https");
                            options.ListenAnyIP(hostingOptions.SecurePort, options =>
                            {
                                var cert = new X509Certificate2(hostingOptions.CertificatePath, hostingOptions.CertificatePassword);
                                options.UseHttps(cert);
                            });
                        }
                    })
            .ConfigureLogging(logging =>
                logging
                    .ClearProviders()
                    .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
            )
            .UseNLog()
            .UseContentRoot(AppContext.BaseDirectory));
}
