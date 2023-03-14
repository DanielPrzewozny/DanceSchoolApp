using System.Data;
using DanceSchoolAPI.Common.Models;
using DanceSchoolAPI.Common.Models.Options;
using DanceSchoolAPI.Common.Models.Query;
using Dapper;

namespace DanceSchoolAPI.Infrastructure.Repositories.MSSQL;

public class MSSQLRepository<TEntity> : BaseSqlRepository<TEntity>, IMSSQLRepository<TEntity>
    where TEntity : EntityBaseDetails
{

    public MSSQLRepository(MSSQLOptions mssqlOptions)
        : base(mssqlOptions)
    {
    }

    public async Task<long> InsertAsync(TEntity entity)
    {
        entity.CreatedOn = entity.CreatedOn == default ? DateTimeOffset.Now : entity.CreatedOn;
        using (IDbConnection conn = await GetConnection())
        {
            var result = await conn.QuerySingleOrDefaultAsync<TEntity>(Insert, entity);
            return result.Id;
        }
    }

    public async Task BatchInsert(IEnumerable<TEntity> entities)
        => await Task.WhenAll(entities.Select(e => InsertAsync(e)));

    public async Task<TEntity> GetAsync(Query queryFilters = null)
    {
        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QueryFirstOrDefaultAsync<TEntity>($"{Select} {queryFilters?.QueryString}", queryFilters?.Parameters);
        }
    }

    public async Task<TEntity> GetAsync(string queryFilters = "", object parameters = null)
    {
        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QueryFirstOrDefaultAsync<TEntity>(!string.IsNullOrEmpty(queryFilters) ? $"{Select} {queryFilters}" : Select, parameters);
        }
    }

    public async Task<IEnumerable<TEntity>> BrowseAsync(Query queryFilters = null)
    {
        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QueryAsync<TEntity>(queryFilters != null ? $"{Browse} {queryFilters.QueryString}" : Select, queryFilters?.Parameters);
        }
    }

    public async Task<IEnumerable<TEntity>> BrowseAsync(string queryFilters = "", object parameters = null)
    {
        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QueryAsync<TEntity>(!string.IsNullOrEmpty(queryFilters) ? $"{Browse} {queryFilters}" : Select, parameters);
        }
    }

    public async Task<bool> ExistsAsync(string queryFilters = "", object parameters = null)
        => await CountAsync(queryFilters, parameters) > 0;

    public async Task<long> CountAsync(Query queryFilters = null)
    {
        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QuerySingleOrDefaultAsync<long>($"SELECT count(*) FROM {tableName} {queryFilters?.QueryString}", queryFilters?.Parameters);
        }
    }

    public async Task<long> CountAsync(string queryFilters = "", object parameters = null)
    {
        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QuerySingleOrDefaultAsync<long>($"{Count}{queryFilters}", parameters);
        }
    }

    public async Task UpdateAsync(Dictionary<string, object> fields, Query queryFilters)
    {
        DynamicParameters parameters = new();

        var idName = columnNames.Where(p => p.Key.ToLower().Equals("id")).Select(p => p.Value).FirstOrDefault();
        string updateQuery = string.Join(", ", fields.Where(u => !u.Key.Contains(idName)).Select(u => $"{u.Key}=@{u.Key}"));

        foreach (var update in fields)
            parameters.Add($"@{update.Key.ToLower()}", update.Value);

        foreach (var filter in queryFilters.Parameters.ParameterNames)
            parameters.Add(filter, queryFilters.Parameters.Get<long>(filter));

        using (IDbConnection conn = await GetConnection())
        {
            var result = await conn.ExecuteAsync($"UPDATE {tableName} SET {updateQuery} {queryFilters.QueryString}", parameters);
        }
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, Query queryFilters, long modifiedById)
    {
        entity.ModifiedOn = entity.ModifiedOn == default ? DateTimeOffset.Now : entity.ModifiedOn;
        entity.ModifiedBy = modifiedById;

        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QuerySingleOrDefaultAsync<TEntity>(Update, entity);
        }
    }

    public async Task RemoveAsync(Query queryFilters)
    {
        using (IDbConnection conn = await GetConnection())
        {
            var tr = conn.BeginTransaction();
            await conn.ExecuteAsync($"{Delete} {queryFilters.QueryString}", queryFilters.Parameters, tr);
            tr.Commit();
        }
    }

    public async Task RemoveAsync(string queryFilters = "", object parameters = null)
    {
        using (IDbConnection conn = await GetConnection())
        {
            var tr = conn.BeginTransaction();
            await conn.ExecuteAsync($"{Delete} {queryFilters}", parameters);
            tr.Commit();
        }
    }
}
