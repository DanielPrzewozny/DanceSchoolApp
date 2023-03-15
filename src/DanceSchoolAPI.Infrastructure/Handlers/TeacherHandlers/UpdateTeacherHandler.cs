using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.Models.Teacher;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.TeacherHandlers;

public class UpdateTeacherHandler : ICommandHandler<UpdateCommand<Teacher>>
{
    private ITeacherService teacherService;

    public UpdateTeacherHandler(ITeacherService teacherService)
    {
        this.teacherService = teacherService;
    }

    public async Task HandleAsync(UpdateCommand<Teacher> command)
        => await teacherService.UpdateAsync(command.Value);
}