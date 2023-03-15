using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Teacher;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.TeacherHandlers;

public class CreateTeacherHandler : IQueryHandler<CreateQuery<Teacher>, long>
{
    private ITeacherService teacherService;

    public CreateTeacherHandler(ITeacherService teacherService)
    {
        this.teacherService = teacherService;
    }

    public async Task<long> HandleAsync(CreateQuery<Teacher> command)
        => await teacherService.CreateAsync(command.Value);
}