using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Exceptions.Interfaces;

public class QueryNotFoundException : Exception
{
    public QueryNotFoundException()
        : base("Query not found")
    {
    }

    public QueryNotFoundException(string queryName)
        : base($"Query with name '{queryName}' not found")
    {
    }

    public QueryNotFoundException(IQuery query)
        : this(query.GetType().Name)
    {
    }
}