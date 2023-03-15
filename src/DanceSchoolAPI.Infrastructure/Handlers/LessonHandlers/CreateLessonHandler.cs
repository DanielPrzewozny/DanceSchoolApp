using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Lesson;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.LessonHandlers;

public class CreateLessonHandler : IQueryHandler<CreateQuery<Lesson>, long>
{
    private ILessonService lessonService;

    public CreateLessonHandler(ILessonService lessonService)
    {
        this.lessonService = lessonService;
    }

    public async Task<long> HandleAsync(CreateQuery<Lesson> command)
        => await lessonService.CreateAsync(command.Value);
}