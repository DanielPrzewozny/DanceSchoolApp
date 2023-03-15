using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.Models.Teacher;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.TeacherHandlers;

public class DeleteTeacherHandler : ICommandHandler<DeleteCommand<Teacher>>
{
    private ITeacherService teacherService;

    public DeleteTeacherHandler(ITeacherService teacherService)
    {
        this.teacherService = teacherService;
    }

    public async Task HandleAsync(DeleteCommand<Teacher> command)
        => await teacherService.DeleteAsync(command.Id);
}