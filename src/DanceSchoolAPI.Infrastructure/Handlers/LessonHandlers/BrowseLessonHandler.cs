using System;
using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Lesson;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.LessonHandlers;

public class BrowseLessonHandler : IQueryHandler<BrowseQuery<Lesson>, IEnumerable<Lesson>>
{
    private ILessonService lessonService;
    public BrowseLessonHandler(ILessonService lessonService)
    {
        this.lessonService = lessonService;
    }

    public async Task<IEnumerable<Lesson>> HandleAsync(BrowseQuery<Lesson> query)
        => await lessonService.BrowseAsync();
}