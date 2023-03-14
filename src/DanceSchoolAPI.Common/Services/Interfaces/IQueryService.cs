using System;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;

namespace DanceSchoolAPI.Common.Services.Interfaces;

public interface IQueryService
{
    bool IsQueryQueryable(Type commandType);
    Type GetQueryType(string routeId);
    IQuery GetQuery(QueryBlueprint payload);
}
