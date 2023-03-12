using DanceSchoolAPI.Common.Repositories.MSSQL;
using DanceSchoolAPI.Extensions;
using DanceSchoolAPI.Models.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DanceSchoolAPI.Modules;

public class RepositoriesModule : ConfigurationModuleBase
{
    protected override void Load(IServiceCollection services, IConfiguration configuration)
    {
        var mssqlOptions = services.AddOptions<MSSQLOptions>(configuration);
        services.AddSingleton(typeof(IMSSQLRepository<>), typeof(MSSQLRepository<>));
    }
}
