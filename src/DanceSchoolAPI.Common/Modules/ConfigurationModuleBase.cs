using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DanceSchoolAPI.Common.Modules;

public abstract class ConfigurationModuleBase : IModule
{
    protected abstract void Load(IServiceCollection services, IConfiguration configuration);

    public void Load(IServiceCollection services)
    {
        IConfiguration configuration;
        using (var provider = services.BuildServiceProvider())
        {
            configuration = provider.GetService<IConfiguration>();
        }

        Load(services, configuration);
    }
}
