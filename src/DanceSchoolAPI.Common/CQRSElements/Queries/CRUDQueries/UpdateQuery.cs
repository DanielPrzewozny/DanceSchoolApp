using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;

public class UpdateQuery<TEntity> : IQuery<string>
{
    public TEntity Value { get; set; }
}