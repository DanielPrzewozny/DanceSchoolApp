using Dapper;

namespace DanceSchoolAPI.Common.Models.Query.Interfaces;

public interface IQueryElement
{
    string ToQueryString<TEntity>(DynamicParameters parameters, ref int index, out object value) where TEntity : EntityBaseDetails;
    string ToQueryString<TEntity>(DynamicParameters parameters, int index = 0) where TEntity : EntityBaseDetails
        => ToQueryString<TEntity>(parameters, ref index, out object _);
}
