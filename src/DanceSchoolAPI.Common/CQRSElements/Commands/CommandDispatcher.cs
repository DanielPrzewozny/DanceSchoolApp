using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.CQRSElements.Exceptions.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider services;

    public CommandDispatcher(IServiceProvider services)
    {
        this.services = services;
    }

    public async Task SendAsync<TCommand>()
        where TCommand : ICommand, new() => await SendAsync<TCommand>(new TCommand());

    public async Task SendAsync<TCommand>(TCommand command)
        where TCommand : ICommand
    {
        if (command is null)
            throw new CommandNotFoundException();

        var handler = services.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;
        if (handler is null)
            throw new CommandNotFoundException(command);

        await handler.HandleAsync(command);
    }
}
