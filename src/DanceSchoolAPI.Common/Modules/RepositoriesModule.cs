using DanceSchoolAPI.Common.Extensions;
using DanceSchoolAPI.Common.Models.Options;
using DanceSchoolAPI.Common.Repositories.MSSQL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DanceSchoolAPI.Common.Modules;

public class RepositoriesModule : ConfigurationModuleBase
{
    protected override void Load(IServiceCollection services, IConfiguration configuration)
    {
        var mssqlOptions = services.AddOptions<MSSQLOptions>(configuration);
        services.AddSingleton(typeof(IMSSQLRepository<>), typeof(MSSQLRepository<>));
    }
}
