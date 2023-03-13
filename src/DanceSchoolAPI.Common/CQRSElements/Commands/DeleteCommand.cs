using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Commands;

public class DeleteCommand<TEntity> : ICommand
{
    public DeleteCommand(string id) => Id = id;

    public string Id { get; set; }
}
