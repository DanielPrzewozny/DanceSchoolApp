using DanceSchoolAPI.Common.Models;
using DanceSchoolAPI.Common.Models.Query;

namespace DanceSchoolAPI.Common.Repositories.MSSQL;
public interface IMSSQLRepository<TEntity> where TEntity : EntityBaseDetails
{
    Task BatchInsert(IEnumerable<TEntity> entities);
    Task<IEnumerable<TEntity>> BrowseAsync(Query queryFilters = null);
    Task<IEnumerable<TEntity>> BrowseAsync(string queryFilters = "", object parameters = null);
    Task<long> CountAsync(Query queryFilters = null);
    Task<long> CountAsync(string queryFilters = "", object parameters = null);
    Task<bool> ExistsAsync(string queryFilters = "", object parameters = null);
    Task<TEntity> GetAsync(Query queryFilters = null);
    Task<TEntity> GetAsync(string queryFilters = "", object parameters = null);
    Task InsertAsync(TEntity entity);
    Task RemoveAsync(string queryFilters = "", object parameters = null);
    Task RemoveAsync(Query queryFilters);
    Task UpdateAsync(Dictionary<string, object> fields, Query queryFilters);
    Task UpdateAsync(TEntity entity, long modifiedById);
}