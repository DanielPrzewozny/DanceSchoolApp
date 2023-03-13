using System.Data;
using System.Data.Common;
using DanceSchoolAPI.Common.Models;
using DanceSchoolAPI.Common.Models.Options;
using DanceSchoolAPI.Common.Models.Query;
using Dapper;

namespace DanceSchoolAPI.Common.Repositories.MSSQL;

public class MSSQLRepository<TEntity> : BaseSqlRepository<TEntity>, IMSSQLRepository<TEntity>
    where TEntity : EntityBaseDetails
{

    public MSSQLRepository(MSSQLOptions mssqlOptions)
        : base(mssqlOptions)
    {
    }

    public async Task InsertAsync(TEntity entity)
    {
        entity.CreatedOn = entity.CreatedOn == default
            ? DateTimeOffset.Now
            : entity.CreatedOn;

        using (IDbConnection conn = await GetConnection())
        {
            await conn.QuerySingleOrDefaultAsync(Insert, entity);
        }
    }

    public async Task BatchInsert(IEnumerable<TEntity> entities)
        => await Task.WhenAll(entities.Select(e => InsertAsync(e)));

    public async Task<TEntity> GetAsync(Query queryFilters = null)
    {
        string query = $"{Select} {queryFilters?.QueryString}";

        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QueryFirstOrDefaultAsync<TEntity>(query, queryFilters?.Parameters);
        }
    }

    public async Task<TEntity> GetAsync(string queryFilters = "", object parameters = null)
    {
        string query = !string.IsNullOrEmpty(queryFilters)
            ? $"{Select} {queryFilters}"
            : Select;

        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QueryFirstOrDefaultAsync<TEntity>(query, parameters);
        }
    }

    public async Task<IEnumerable<TEntity>> BrowseAsync(Query queryFilters = null)
    {
        DynamicParameters parameters = new();
        string query = queryFilters != null
            ? $"{Browse} {queryFilters.QueryString}"
            : Select;

        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QueryAsync<TEntity>(query, queryFilters?.Parameters);
        }
    }

    public async Task<IEnumerable<TEntity>> BrowseAsync(string queryFilters = "", object parameters = null)
    {
        string query = !string.IsNullOrEmpty(queryFilters)
            ? $"{Browse} {queryFilters}"
            : Select;

        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QueryAsync<TEntity>(query, parameters);
        }
    }

    public async Task<bool> ExistsAsync(string queryFilters = "", object parameters = null)
        => await CountAsync(queryFilters, parameters) > 0;

    public async Task<long> CountAsync(Query queryFilters = null)
    {
        string query = $"SELECT count(*) FROM {tableName} {queryFilters?.QueryString}";

        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QuerySingleOrDefaultAsync<long>(query, queryFilters?.Parameters);
        }
    }

    public async Task<long> CountAsync(string queryFilters = "", object parameters = null)
    {
        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QuerySingleOrDefaultAsync<long>(Count + queryFilters, parameters);
        }
    }

    public async Task UpdateAsync(Dictionary<string, object> fields, Query queryFilters)
    {
        DynamicParameters parameters = new();

        foreach (var update in fields)
        {
            parameters.Add($"@{update.Key.ToLower()}", update.Value);
        }

        foreach (var filter in queryFilters.Parameters.ParameterNames)
        {
            parameters.Add(filter, queryFilters.Parameters.Get<long>(filter));
        }
        var idName = columnNames.Where(p => p.Key.ToLower().Equals("id")).Select(p => p.Value).FirstOrDefault();
        string updateQuery = string.Join(", ", fields.Where(u => !u.Key.Contains(idName)).Select(u => $"{u.Key}=@{u.Key}"));

        string query = $"UPDATE {tableName} SET {updateQuery} {queryFilters.QueryString}";

        using (IDbConnection conn = await GetConnection())
        {
            var result = await conn.ExecuteAsync(query, parameters);
        }
    }
    public async Task UpdateAsync(TEntity entity, long modifiedById)
    {
        entity.ModifiedOn = entity.ModifiedOn == default
            ? DateTimeOffset.Now
            : entity.ModifiedOn;
        entity.ModifiedBy = modifiedById;

        using (IDbConnection conn = await GetConnection())
        {
            await conn.ExecuteAsync(Update);
        }
    }

    public async Task RemoveAsync(Query queryFilters)
    {
        string query = $"{Delete} {queryFilters.QueryString}";

        using (IDbConnection conn = await GetConnection())
        {
            var tr = conn.BeginTransaction();
            await conn.ExecuteAsync(query, queryFilters.Parameters, tr);
            tr.Commit();
        }
    }

    public async Task RemoveAsync(string queryFilters = "", object parameters = null)
    {
        string query = $"{Delete} {queryFilters}";
        using (IDbConnection conn = await GetConnection())
        {
            var tr = conn.BeginTransaction();
            await conn.ExecuteAsync(query, parameters);
            tr.Commit();
        }
    }
}
