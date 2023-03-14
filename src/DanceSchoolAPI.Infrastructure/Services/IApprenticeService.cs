using DanceSchoolAPI.Common.Models.Apprentice;

namespace DanceSchoolAPI.Infrastructure.Services;
public interface IApprenticeService
{
    Task<long> CreateAsync(Apprentice apprenticeData);
    Task<Apprentice> GetAsync(long apprenticeId);
}