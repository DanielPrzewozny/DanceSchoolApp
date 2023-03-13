using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;

public class CreateQuery<TEntity> : IQuery<string>
{
    public TEntity Value { get; set; }
}