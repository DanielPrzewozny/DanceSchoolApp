using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Commands;

public class DeleteCommand<TEntity> : ICommand
{
    public DeleteCommand(long id) => Id = id;

    public long Id { get; set; }
}
