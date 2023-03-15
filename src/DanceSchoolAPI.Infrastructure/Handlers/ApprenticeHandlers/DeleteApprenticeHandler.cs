using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.Models.Apprentice;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.ApprenticeHandlers;

public class DeleteApprenticeHandler : ICommandHandler<DeleteCommand<Apprentice>>
{
    private IApprenticeService apprenticeService;

    public DeleteApprenticeHandler(IApprenticeService apprenticeService)
    {
        this.apprenticeService = apprenticeService;
    }

    public async Task HandleAsync(DeleteCommand<Apprentice> command)
        => await apprenticeService.DeleteAsync(command.Id);
}