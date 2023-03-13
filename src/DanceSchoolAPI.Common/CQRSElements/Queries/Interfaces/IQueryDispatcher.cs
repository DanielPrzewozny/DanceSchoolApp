
namespace DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TQuery, TResult>()
        where TQuery : IQuery<TResult>, new();
    Task<TResult> QueryAsync<TQuery, TResult>(TQuery query)
        where TQuery : IQuery<TResult>;
    Task<TResult> QueryDynamicAsync<TResult>(IQuery<TResult> query);
}