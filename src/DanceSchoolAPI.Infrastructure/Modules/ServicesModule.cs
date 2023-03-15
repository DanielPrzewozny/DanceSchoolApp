using DanceSchoolAPI.Common.Modules;
using DanceSchoolAPI.Infrastructure.Services;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EventRuleAPI.Infrastructure.Modules;

public class ServicesModule : IModule
{
    public void Load(IServiceCollection services)
    {
        services.AddSingleton<IApprenticeService, ApprenticeService>();
        services.AddSingleton<ILessonService, LessonService>();
        services.AddSingleton<ITeacherService, TeacherService>();
    }
}
