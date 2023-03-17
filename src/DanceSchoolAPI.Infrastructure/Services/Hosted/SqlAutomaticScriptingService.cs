using System.Text.RegularExpressions;
using DanceSchoolAPI.Infrastructure.Options;
using DanceSchoolAPI.Infrastructure.Repositories.MSSQL;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Infrastructure.Services.Hosted;

public class SqlAutomaticScriptingService : IHostedService, IDisposable
{
    private readonly IMSSQLRepository<DboVersion> versionRepository;
    private readonly ILogger<SqlAutomaticScriptingService> logger;
    private readonly MSSQLScriptsOptions mssqlScriptsOptions;

    public SqlAutomaticScriptingService(
        IMSSQLRepository<DboVersion> versionRepository,
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
        var ver = await versionRepository.SelectAsync();
        if (ver is null)
        {
            logger.LogInformation("Initializing database.");
            await RunScriptsFromFileAsync(mssqlScriptsOptions.SchemaPath);
            await RunScriptsFromFileAsync(mssqlScriptsOptions.InitPath);
        }

        await RunScriptsFromFolderAsync(ver?.LastOrDefault());
    }

    private async Task RunScriptsFromFileAsync(string scriptPath)
    {
        var listOfqueries = File.Exists(scriptPath)
            ? Regex.Replace(string.Join(" ", await File.ReadAllLinesAsync(scriptPath)), @"[\r|\n|\t]", " ")
            .Split(';')
            .Where(x => !string.IsNullOrWhiteSpace(x) && !string.IsNullOrEmpty(x))
        .ToList()
        : null;

        if (listOfqueries is not null && listOfqueries.Any())
            await versionRepository.ExecuteQueriesAsync(listOfqueries);
    }

    private async Task RunScriptsFromFolderAsync(DboVersion? actualVersion = null)
    {
        actualVersion ??= (await versionRepository.SelectAsync()).LastOrDefault();

        if (!Version.TryParse(actualVersion?.Version, out Version? ver))
            return;

        var listOfScripts = Directory.Exists(mssqlScriptsOptions.ScriptsPath)
            ? Directory.GetFiles(mssqlScriptsOptions.ScriptsPath)
                .Where(v => Version.TryParse(Path.GetFileNameWithoutExtension(v), out Version? nameV)
                    && nameV > ver).ToList()
            : null;

        if (listOfScripts is not null && listOfScripts.Any())
            foreach (var script in listOfScripts)
                await RunScriptsFromFileAsync(script);
    }
}

