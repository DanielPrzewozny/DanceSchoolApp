using DanceSchoolAPI.Common.Enums;

namespace DanceSchoolAPI.Common.Extensions;

public static class AggregatorTypeExtensions
{
    public static string ToQueryString(this AggregatorType aggregatorType) => aggregatorType switch
    {
        AggregatorType.And => "AND",
        AggregatorType.Or => "OR",
        _ => string.Empty
    };
}

