
namespace DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;

public interface IRoutedCommand : ICommand
{
    string CommandName { get; }
}
