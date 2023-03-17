using System.Text.RegularExpressions;
using DanceSchoolAPI.Infrastructure.Options;
using DanceSchoolAPI.Infrastructure.Repositories.MSSQL;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Infrastructure.Services.Hosted;

public class SqlAutomaticScriptingService : IHostedService, IDisposable
{
    private readonly IMSSQLRepository<Repositories.MSSQL.Version> versionRepository;
    private readonly ILogger<SqlAutomaticScriptingService> logger;
    private readonly MSSQLScriptsOptions mssqlScriptsOptions;

    public SqlAutomaticScriptingService(
        IMSSQLRepository<Repositories.MSSQL.Version> versionRepository,
        ILogger<SqlAutomaticScriptingService> logger,
        MSSQLScriptsOptions mssqlScriptsOptions)
    {
        this.versionRepository = versionRepository;
        this.logger = logger;
        this.mssqlScriptsOptions = mssqlScriptsOptions;
    }

    public void Dispose()
    {
    }

    public async Task StartAsync(CancellationToken cancellationToken)
        => await ExecuteScriptsAsync();

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public async Task ExecuteScriptsAsync()
    {
        var ver = versionRepository.SelectAsync();
        if (ver is null)
        {
            logger.LogError("Vesion of database not exists");
            await RunScriptsFromFileAsync(mssqlScriptsOptions.SchemaPath);
            await RunScriptsFromFileAsync(mssqlScriptsOptions.InitPath);
        }
    }

    public async Task RunScriptsFromFileAsync(string scriptPath)
    {
        var dataPath = Path.Join(Directory.GetCurrentDirectory(), scriptPath);
        var listOfqueries = File.Exists(scriptPath)
            ? Regex.Replace(string.Join(" ", await File.ReadAllLinesAsync(scriptPath)), @"[\r|\n|\t]", " ")
            .Split(';')
            .Where(x => !string.IsNullOrWhiteSpace(x) && !string.IsNullOrEmpty(x))
            .ToList()
            : null;

        if (listOfqueries?.Any() is not null)
            await versionRepository.ExecuteQueriesAsync(listOfqueries);
    }
}
