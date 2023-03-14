using DanceSchoolAPI.Common.Models.Apprentice;
using DanceSchoolAPI.Common.Models.Query;
using DanceSchoolAPI.Infrastructure.Repositories.MSSQL;
using Dapper;

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

    public async Task<Apprentice> GetAsync(long apprenticeId)
        => await apprenticeRepository.GetAsync("WHERE Id = @Id", new DynamicParameters(new { Id = apprenticeId }));
}
