using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.Models.ClubCard;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.ClubCardHandlers;

public class DeleteClubCardHandler : ICommandHandler<DeleteCommand<ClubCard>>
{
    private IClubCardService clubCardService;

    public DeleteClubCardHandler(IClubCardService clubCardService)
    {
        this.clubCardService = clubCardService;
    }

    public async Task HandleAsync(DeleteCommand<ClubCard> command)
        => await clubCardService.DeleteAsync(command.Id);
}