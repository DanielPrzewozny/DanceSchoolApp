using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Teacher;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.TeacherHandlers;

public class BrowseTeacherHandler : IQueryHandler<BrowseQuery<Teacher>, IEnumerable<Teacher>>
{
    private ITeacherService teacherService;
    public BrowseTeacherHandler(ITeacherService teacherService)
    {
        this.teacherService = teacherService;
    }

    public async Task<IEnumerable<Teacher>> HandleAsync(BrowseQuery<Teacher> query)
        => await teacherService.BrowseAsync();
}