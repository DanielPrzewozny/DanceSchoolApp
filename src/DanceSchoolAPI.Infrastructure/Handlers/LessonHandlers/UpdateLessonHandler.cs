using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.Models.Lesson;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.LessonHandlers;

public class UpdateLessonHandler : ICommandHandler<UpdateCommand<Lesson>>
{
    private ILessonService lessonService;

    public UpdateLessonHandler(ILessonService lessonService)
    {
        this.lessonService = lessonService;
    }

    public async Task HandleAsync(UpdateCommand<Lesson> command)
        => await lessonService.UpdateAsync(command.Value);
}