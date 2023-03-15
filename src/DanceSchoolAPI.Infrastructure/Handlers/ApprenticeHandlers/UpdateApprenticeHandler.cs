using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.Models.Apprentice;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.ApprenticeHandlers;

public class UpdateApprenticeHandler : ICommandHandler<UpdateCommand<Apprentice>>
{
    private IApprenticeService apprenticeService;

    public UpdateApprenticeHandler(IApprenticeService apprenticeService)
    {
        this.apprenticeService = apprenticeService;
    }

    public async Task HandleAsync(UpdateCommand<Apprentice> command)
        => await apprenticeService.UpdateAsync(command.Value);
}