using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Teacher;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.TeacherHandlers;

public class GetTeacherHandler : IQueryHandler<GetQuery<Teacher>, Teacher>
{
    private ITeacherService teacherService;

    public GetTeacherHandler(ITeacherService teacherService)
    {
        this.teacherService = teacherService;
    }

    public async Task<Teacher> HandleAsync(GetQuery<Teacher> command)
        => await teacherService.GetAsync(command.Id);
}