using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.ClubCard;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.ClubCardHandlers;

public class GetClubCardHandler : IQueryHandler<GetQuery<ClubCard>, ClubCard>
{
    private IClubCardService clubCardService;

    public GetClubCardHandler(IClubCardService clubCardService)
    {
        this.clubCardService = clubCardService;
    }

    public async Task<ClubCard> HandleAsync(GetQuery<ClubCard> command)
        => await clubCardService.GetAsync(command.Id);
}