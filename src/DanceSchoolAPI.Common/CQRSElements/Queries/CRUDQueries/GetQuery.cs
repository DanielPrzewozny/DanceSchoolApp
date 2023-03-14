using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;

public class GetQuery<TEntity> : IQuery<TEntity>
{
    public GetQuery(long id) => Id = id;

    public long Id { get; set; }
}