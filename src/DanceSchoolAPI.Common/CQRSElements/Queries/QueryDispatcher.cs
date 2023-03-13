using DanceSchoolAPI.Common.CQRSElements.Exceptions.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider services;

    public QueryDispatcher(IServiceProvider services)
    {
        this.services = services;
    }

    public async Task<TResult> QueryAsync<TIQuery, TResult>()
        where TIQuery : IQuery<TResult>, new() => await QueryAsync<TIQuery, TResult>(new TIQuery());

    public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query)
        where TQuery : IQuery<TResult>
    {
        if (query is null)
            throw new QueryNotFoundException();
        var handler = services.GetService(typeof(IQueryHandler<TQuery, TResult>)) as IQueryHandler<TQuery, TResult>;
        if (handler is null)
            throw new QueryNotFoundException(query);

        return await handler.HandleAsync(query);
    }

    public async Task<TResult> QueryDynamicAsync<TResult>(IQuery<TResult> query)
    {
        if (query is null)
            throw new QueryNotFoundException();

        dynamic handler = services.GetService(typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult)));
        if (handler is null)
            throw new QueryNotFoundException(query);

        return await handler.HandleAsync((dynamic)query);
    }
}