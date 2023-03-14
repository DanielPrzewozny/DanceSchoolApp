using System;
using System.Linq;
using DanceSchoolAPI.Common.CQRSElements.Exceptions.Interfaces;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Extensions;
using DanceSchoolAPI.Common.Services.Interfaces;

namespace DanceSchoolAPI.Common.Services;

public class QueryService : IQueryService
{
    private readonly IReadOnlyDictionary<string, Type> registeredTypes;

    public QueryService(Dictionary<string, Type> registeredTypes)
    {
        this.registeredTypes = registeredTypes;
    }

    public bool IsQueryQueryable(Type commandType)
        => commandType.GetInterfaces()
            .Any(o => o.IsGenericType && o.GetGenericTypeDefinition() == typeof(IQuery<>));

    public Type GetQueryType(string commandName)
        => registeredTypes.ContainsKey(commandName) ? registeredTypes[commandName] : null;

    public IQuery GetQuery(QueryBlueprint blueprint)
    {
        var commandType = GetQueryType(blueprint.QueryName);
        if (commandType == null)
            throw new QueryNotFoundException(blueprint.QueryName);

        return blueprint.Payload.Deserialize(commandType) as IQuery;
    }
}
