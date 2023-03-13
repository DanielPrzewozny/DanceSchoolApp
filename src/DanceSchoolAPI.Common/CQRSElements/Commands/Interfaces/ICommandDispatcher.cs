
namespace DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>()
        where TCommand : ICommand, new();
    Task SendAsync<TCommand>(TCommand command)
        where TCommand : ICommand;
}