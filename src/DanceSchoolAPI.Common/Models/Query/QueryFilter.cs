using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using DanceSchoolAPI.Common.Enums;
using DanceSchoolAPI.Common.Extensions;
using DanceSchoolAPI.Common.Models.Query.Interfaces;
using Dapper;

namespace DanceSchoolAPI.Common.Models.Query;

public class QueryFilter : IQueryElement
{
    private readonly static BindingFlags bindingFlags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
    private readonly static FilterType[] bracketableFilters = new FilterType[] { FilterType.In, FilterType.NotIn, FilterType.LikeAny, FilterType.IlikeAny };

    public readonly string ColumnName;
    public object Value;
    public readonly FilterType filterType;
    public readonly bool? Descending = null;
    public string QueryString { get; set; }

    public QueryFilter(string columnName, FilterType filterType, object value, bool? descending)
    {
        this.ColumnName = columnName;
        this.Value = value;
        this.filterType = filterType;
        this.Descending = descending;
        QueryString = filterType.ToQueryString();
    }

    public string ToQueryString<TEntity>(DynamicParameters parameters, ref int index, out object value) where TEntity : EntityBaseDetails
    {
        PropertyInfo property = typeof(TEntity).GetProperty(ColumnName, bindingFlags);
        string columnName = property.GetCustomAttribute<ColumnAttribute>()?.Name ?? ColumnName;

        if (Value != null)
        {
            if (property.PropertyType == typeof(DateTimeOffset) || property.PropertyType == typeof(DateTimeOffset?))
            {
                DateTimeOffset result;
                DateTimeOffset.TryParse(Value.ToString(), out result);

                if (filterType == FilterType.LessOrEquals) result = result.AddDays(1).AddHours(-2).AddMilliseconds(-1);

                value = result;
            }
            else
            {
                value = Value is not string && Value is IEnumerable enumerable
                        ? enumerable.Cast<object>().Select(v => Convert.ChangeType(v, GetPropType(property)))
                        : Convert.ChangeType(Value, GetPropType(property));
            }
        }
        else
        {
            value = null;
        }

        if (value is null) return null;
        else return IsBracketable()
            ? $"{columnName} {QueryString} (@param{index})"
            : $"{columnName} {QueryString} @param{index}";

    }

    public string ToQueryString<TEntity>(DynamicParameters parameters, int index = 0) where TEntity : EntityBaseDetails
        => ToQueryString<TEntity>(parameters, ref index, out object _);

    private static Type GetPropType(PropertyInfo property)
        => Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

    private bool IsBracketable()
        => bracketableFilters.Contains(filterType);

}
