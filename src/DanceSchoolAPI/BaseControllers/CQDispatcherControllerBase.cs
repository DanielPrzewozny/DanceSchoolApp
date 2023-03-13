using System.Threading.Tasks;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DanceSchoolAPI.BaseControllers;

public abstract class CQDispatcherControllerBase : Controller
{
    private readonly ICommandDispatcher commandDispatcher;
    private readonly IQueryDispatcher queryDispatcher;
    public CQDispatcherControllerBase(
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        this.commandDispatcher = commandDispatcher;
        this.queryDispatcher = queryDispatcher;
    }

    protected async Task CommandAsync<TCommand>(TCommand command)
        where TCommand : ICommand => await commandDispatcher.SendAsync(command);

    protected async Task CommandAsync<TCommand>()
        where TCommand : ICommand, new()
        => await CommandAsync(new TCommand());

    protected async Task<TResult> QueryAsync<TCommand, TResult>(TCommand command)
        where TCommand : IQuery<TResult> => await queryDispatcher.QueryAsync<TCommand, TResult>(command);

    protected async Task<TResult> QueryAsync<TCommand, TResult>()
        where TCommand : IQuery<TResult>, new()
        => await QueryAsync<TCommand, TResult>(new TCommand());
}