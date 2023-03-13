using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;

public class BrowseQuery<TEntity> : IQuery<IEnumerable<TEntity>>
{
}