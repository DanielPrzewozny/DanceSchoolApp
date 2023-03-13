using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;

public class GetQuery<TEntity> : IQuery<TEntity>
{
    public GetQuery(string id) => Id = id;

    public string Id { get; set; }
}