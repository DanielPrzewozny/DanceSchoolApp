using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.Models.Lesson;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.LessonHandlers;

public class DeleteLessonHandler : ICommandHandler<DeleteCommand<Lesson>>
{
    private ILessonService lessonService;

    public DeleteLessonHandler(ILessonService lessonService)
    {
        this.lessonService = lessonService;
    }

    public async Task HandleAsync(DeleteCommand<Lesson> command)
        => await lessonService.DeleteAsync(command.Id);
}