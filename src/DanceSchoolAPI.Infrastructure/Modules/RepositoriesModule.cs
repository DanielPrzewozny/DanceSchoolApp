using DanceSchoolAPI.Common.Extensions;
using DanceSchoolAPI.Common.Models.Options;
using DanceSchoolAPI.Common.Modules;
using DanceSchoolAPI.Infrastructure.Repositories.MSSQL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DanceSchoolAPI.Infrastructure.Modules;

public class RepositoriesModule : ConfigurationModuleBase
{
    protected override void Load(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<MSSQLOptions>(configuration);
        services.AddSingleton(typeof(IMSSQLRepository<>), typeof(MSSQLRepository<>));
    }
}
