using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.Models.ClubCard;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.ClubCardHandlers;

public class UpdateClubCardHandler : ICommandHandler<UpdateCommand<ClubCard>>
{
    private IClubCardService clubCardService;

    public UpdateClubCardHandler(IClubCardService clubCardService)
    {
        this.clubCardService = clubCardService;
    }

    public async Task HandleAsync(UpdateCommand<ClubCard> command)
        => await clubCardService.UpdateAsync(command.Value);
}