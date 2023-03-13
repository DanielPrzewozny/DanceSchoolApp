using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;

namespace DanceSchoolAPI.Common.CQRSElements.Commands;

public class UpdateCommand<TEntity> : ICommand
{
    public UpdateCommand(TEntity value) => Value = value;

    public TEntity Value { get; set; }
}
