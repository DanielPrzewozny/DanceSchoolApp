using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Lesson;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.LessonHandlers;

public class GetLessonHandler : IQueryHandler<GetQuery<Lesson>, Lesson>
{
    private ILessonService lessonService;

    public GetLessonHandler(ILessonService lessonService)
    {
        this.lessonService = lessonService;
    }

    public async Task<Lesson> HandleAsync(GetQuery<Lesson> command)
        => await lessonService.GetAsync(command.Id);
}