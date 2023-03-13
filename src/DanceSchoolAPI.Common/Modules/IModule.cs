using Microsoft.Extensions.DependencyInjection;

namespace DanceSchoolAPI.Common.Modules;

public interface IModule
{
    void Load(IServiceCollection services);
}
