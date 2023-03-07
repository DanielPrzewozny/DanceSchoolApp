using Microsoft.Extensions.DependencyInjection;

namespace DanceSchoolAPI.Modules;

public interface IModule
{
    void Load(IServiceCollection services);
}
