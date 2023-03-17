using System.Data;
using System.Text.RegularExpressions;
using DanceSchoolAPI.Common.Models;
using DanceSchoolAPI.Infrastructure.Options;
using Dapper;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Infrastructure.Repositories.MSSQL;

public class MSSQLRepository<TEntity> : BaseSqlRepository<TEntity>, IMSSQLRepository<TEntity>
    where TEntity : EntityBaseDetails
{
    private readonly ILogger<MSSQLRepository<TEntity>> logger;
    public MSSQLRepository(
        MSSQLOptions mssqlOptions,
        ILogger<MSSQLRepository<TEntity>> logger)
        : base(mssqlOptions)
    {
        this.logger = logger;
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

    public async Task<TEntity> GetAsync(long id)
    {
        DynamicParameters paramGet = new DynamicParameters();
        paramGet.Add("@id", id);

        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QuerySingleOrDefaultAsync<TEntity>($"{Select} WHERE Id=@id;", paramGet);
        }
    }

    public async Task<IEnumerable<TEntity>> SelectAsync()
    {
        using (IDbConnection conn = await GetConnection())
        {
            try
            {
                return await conn.QueryAsync<TEntity>(Select);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return null;
        }
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, long modifiedById)
    {
        entity.ModifiedOn = entity.ModifiedOn == default ? DateTimeOffset.Now : entity.ModifiedOn;
        entity.ModifiedBy = modifiedById;

        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QuerySingleOrDefaultAsync<TEntity>
                ($"{Update} WHERE Id=@Id; SELECT * FROM {tableName} WHERE Id=@Id;", entity);
        }
    }

    public async Task DeleteAsync(long id)
    {
        DynamicParameters paramDelete = new DynamicParameters();
        paramDelete.Add("@id", id);

        using (IDbConnection conn = await GetConnection())
        {
            await conn.ExecuteAsync($"{Delete} WHERE Id=@id;", paramDelete);
        }
    }

    public async Task ExecuteQueriesAsync(IEnumerable<string> listOfScripts)
    {
        using (IDbConnection conn = await GetConnection())
        {
            foreach (var script in listOfScripts)
            {
                try
                {
                    if (!string.IsNullOrEmpty(script))
                        await conn.ExecuteAsync(script);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
