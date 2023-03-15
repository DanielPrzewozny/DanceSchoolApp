using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.ClubCard;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.ClubCardHandlers;

public class CreateClubCardHandler : IQueryHandler<CreateQuery<ClubCard>, long>
{
    private IClubCardService clubCardService;

    public CreateClubCardHandler(IClubCardService clubCardService)
    {
        this.clubCardService = clubCardService;
    }

    public async Task<long> HandleAsync(CreateQuery<ClubCard> command)
        => await clubCardService.CreateAsync(command.Value);
}