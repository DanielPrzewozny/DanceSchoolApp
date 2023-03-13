using DanceSchoolAPI.Common.Enums;

namespace DanceSchoolAPI.Common.Extensions;

public static class FilterTypeExtension
{
    public static string ToQueryString(this FilterType filterType) => filterType switch
    {
        FilterType.In => "IN",
        FilterType.Equal => "=",
        FilterType.Greater => ">",
        FilterType.GreaterOrEquals => ">=",
        FilterType.Less => "<",
        FilterType.LessOrEquals => "<=",
        FilterType.Like => "LIKE",
        FilterType.Ilike => "ILIKE",
        FilterType.Is => "IS",
        FilterType.Not => "NOT",
        FilterType.NotIn => "NOT IN",
        FilterType.IsNot => "IS NOT",
        FilterType.LikeAny => "LIKE ANY",
        FilterType.IlikeAny => "ILIKE ANY",
        _ => string.Empty
    };
}
