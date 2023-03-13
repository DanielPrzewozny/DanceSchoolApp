
namespace DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;

public interface ICommand
{
}

public interface ICommand<TResult> : ICommand
{
}