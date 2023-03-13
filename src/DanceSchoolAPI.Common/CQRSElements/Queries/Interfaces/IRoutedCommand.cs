
namespace DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

public interface IRoutedQuery : IQuery
{
    string QueryName { get; }
}
