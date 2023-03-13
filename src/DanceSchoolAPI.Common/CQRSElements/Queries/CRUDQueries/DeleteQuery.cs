using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;

public class DeleteQuery<TEntity> : IQuery<string>
{
    public string Id { get; set; }
}