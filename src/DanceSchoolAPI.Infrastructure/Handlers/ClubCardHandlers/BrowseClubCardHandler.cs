using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.ClubCard;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.ClubCardHandlers;

public class BrowseClubCardHandler : IQueryHandler<BrowseQuery<ClubCard>, IEnumerable<ClubCard>>
{
    private IClubCardService clubCardService;
    public BrowseClubCardHandler(IClubCardService clubCardService)
    {
        this.clubCardService = clubCardService;
    }

    public async Task<IEnumerable<ClubCard>> HandleAsync(BrowseQuery<ClubCard> query)
        => await clubCardService.BrowseAsync();
}