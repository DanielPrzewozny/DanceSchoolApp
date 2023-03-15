using DanceSchoolAPI.Common.Models.Apprentice;
using DanceSchoolAPI.Infrastructure.Repositories.MSSQL;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Services;

public class ApprenticeService : IApprenticeService
{
    private IMSSQLRepository<Apprentice> apprenticeRepository;

    public ApprenticeService(
        IMSSQLRepository<Apprentice> apprenticeRepository)
    {
        this.apprenticeRepository = apprenticeRepository;
    }

    public async Task<long> CreateAsync(Apprentice apprenticeData)
        => await apprenticeRepository.InsertAsync(apprenticeData);

    public async Task<Apprentice> GetAsync(long id)
        => await apprenticeRepository.GetAsync(id);

    public async Task<IEnumerable<Apprentice>> BrowseAsync()
        => await apprenticeRepository.SelectAsync();

    public async Task<Apprentice> UpdateAsync(Apprentice apprenticeData)
        => await apprenticeRepository.UpdateAsync(apprenticeData, 0);

    public async Task DeleteAsync(long id)
        => await apprenticeRepository.DeleteAsync(id);
}
