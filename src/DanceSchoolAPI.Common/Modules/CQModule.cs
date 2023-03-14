using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DanceSchoolAPI.Common.Modules;
public class CQModule : IModule
{
    public void Load(IServiceCollection services)
    {
        services.AddAssemblyTypes(typeof(ICommandHandler<>), ServiceLifetime.Singleton);
        services.AddAssemblyTypes(typeof(ICommandHandler<,>), ServiceLifetime.Singleton);
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

        services.AddAssemblyTypes(typeof(IQueryHandler<,>), ServiceLifetime.Singleton);
        services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
    }
}
