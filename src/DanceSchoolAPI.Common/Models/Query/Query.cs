using Dapper;

namespace DanceSchoolAPI.Common.Models.Query;

public class Query
{
    public string QueryString { get; set; }
    public DynamicParameters Parameters { get; set; }

    public Query(string query, DynamicParameters parameters)
    {
        QueryString = query;
        Parameters = parameters;
    }
}