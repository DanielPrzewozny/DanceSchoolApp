using DanceSchoolAPI.Common.Models.Apprentice;

namespace DanceSchoolAPI.Infrastructure.Services;
public interface IApprenticeService
{
    Task<long> CreateAsync(Apprentice apprenticeData);
    Task<Apprentice> GetAsync(long id);
    Task<IEnumerable<Apprentice>> BrowseAsync();
    Task<Apprentice> UpdateAsync(Apprentice apprenticeData);
    Task DeleteAsync(long id);
}