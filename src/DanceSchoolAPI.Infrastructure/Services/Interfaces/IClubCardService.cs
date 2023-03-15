using DanceSchoolAPI.Common.Models.ClubCard;

namespace DanceSchoolAPI.Infrastructure.Services.Interfaces;
public interface IClubCardService
{
    Task<IEnumerable<ClubCard>> BrowseAsync();
    Task<long> CreateAsync(ClubCard data);
    Task DeleteAsync(long id);
    Task<ClubCard> GetAsync(long id);
    Task<ClubCard> UpdateAsync(ClubCard data);
}