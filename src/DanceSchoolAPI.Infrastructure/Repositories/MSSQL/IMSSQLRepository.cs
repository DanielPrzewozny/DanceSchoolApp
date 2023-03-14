using DanceSchoolAPI.Common.Models;

namespace DanceSchoolAPI.Infrastructure.Repositories.MSSQL;
public interface IMSSQLRepository<TEntity> where TEntity : EntityBaseDetails
{
    Task<IEnumerable<TEntity>> SelectAsync();
    Task<TEntity> GetAsync(long id);
    Task<long> InsertAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity, long modifiedById);
    Task DeleteAsync(long id);
}