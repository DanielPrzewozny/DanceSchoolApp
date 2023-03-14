using System.Data;
using DanceSchoolAPI.Common.Models;
using DanceSchoolAPI.Common.Models.Options;
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

    public async Task<TEntity> GetAsync(long id)
    {
        DynamicParameters paramGet = new DynamicParameters();
        paramGet.Add("@id", id);

        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QuerySingleOrDefaultAsync<TEntity>($"{Select} WHERE Id=@Id;", paramGet);
        }
    }

    public async Task<IEnumerable<TEntity>> SelectAsync()
    {
        using (IDbConnection conn = await GetConnection())
        {
            return await conn.QueryAsync<TEntity>(Select);
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
}
