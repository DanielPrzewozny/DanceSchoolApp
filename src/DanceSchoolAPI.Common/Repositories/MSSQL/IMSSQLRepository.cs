using System.Data.Common;
using DanceSchoolAPI.Common.Models;
using DanceSchoolAPI.Common.Models.Query;

namespace DanceSchoolAPI.Common.Repositories.MSSQL;

public interface IMSSQLRepository<TEntity> where TEntity : EntityBaseDetails
{
    Task<IEnumerable<long>> BatchInsert(IEnumerable<TEntity> entities);
    Task<IEnumerable<TEntity>> BrowseAsync(Query queryFilters = null);
    Task<IEnumerable<TEntity>> BrowseAsync(string queryFilters = "", object parameters = null);
    Task<long> CountAsync(Query queryFilters = null);
    Task<long> CountAsync(string queryFilters = "", object parameters = null);
    Task<bool> ExistsAsync(Query queryFilters = null);
    Task<bool> ExistsAsync(string queryFilters = "", object parameters = null);
    Task<TEntity> GetAsync(Query queryFilters = null);
    Task<TEntity> GetAsync(string queryFilters = "", object parameters = null);
    Task<long> InsertAsync(TEntity entity, DbConnection connection = null, DbTransaction transaction = null, bool closeConnection = true);
    Task<int> RemoveAsync(string queryFilters = "", object parameters = null);
    Task<int> RemoveAsync(Query queryFilters);
    Task<TEntity> UpdateAsync(Dictionary<string, object> fields, Query queryFilters);
    Task UpdateAsync(TEntity entity, long modifiedById);
}