using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;

public class CreateQuery<TEntity> : IQuery<long>
{
    public CreateQuery(TEntity value) => Value = value;

    public TEntity Value { get; set; }
}