using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Exceptions.Interfaces;

public class CommandNotFoundException : Exception
{
    public CommandNotFoundException()
    : base("Command not found")
    {
    }

    public CommandNotFoundException(string commandName)
        : base($"Command with name '{commandName}' not found")
    {
    }

    public CommandNotFoundException(ICommand command)
        : this(command.GetType().Name)
    {
    }
}