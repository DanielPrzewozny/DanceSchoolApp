using DanceSchoolAPI.Common.Models.ClubCard;
using DanceSchoolAPI.Infrastructure.Repositories.MSSQL;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Services;

public class ClubCardService : IClubCardService
{
    private IMSSQLRepository<ClubCard> clubCardRepository;

    public ClubCardService(
        IMSSQLRepository<ClubCard> clubCardRepository)
    {
        this.clubCardRepository = clubCardRepository;
    }

    public async Task<long> CreateAsync(ClubCard data)
        => await clubCardRepository.InsertAsync(data);

    public async Task<ClubCard> GetAsync(long id)
        => await clubCardRepository.GetAsync(id);

    public async Task<IEnumerable<ClubCard>> BrowseAsync()
        => await clubCardRepository.SelectAsync();

    public async Task<ClubCard> UpdateAsync(ClubCard data)
        => await clubCardRepository.UpdateAsync(data, 0);

    public async Task DeleteAsync(long id)
        => await clubCardRepository.DeleteAsync(id);
}
