using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Reflection;
using DanceSchoolAPI.Common.Models;
using DanceSchoolAPI.Common.Models.Options;
using Microsoft.Data.SqlClient;

namespace DanceSchoolAPI.Infrastructure.Repositories.MSSQL;

public abstract class BaseSqlRepository<TEntity>
    where TEntity : EntityBaseDetails
{
    private readonly MSSQLOptions mssqlOptions;

    protected readonly string select = "SELECT {0} FROM {1}";
    protected readonly string count = "SELECT COUNT(*) FROM {1}";
    protected readonly string browse = "SELECT COUNT(*) OVER() AS \"DataCount\", {0} FROM {1}";
    protected readonly string insert = "INSERT INTO {0}({1}) VALUES ({2}); SELECT * FROM {0} WHERE Id = (SELECT CAST(scope_identity() as int));";
    protected readonly string update = "UPDATE {0} SET {1}";
    protected readonly string delete = "DELETE FROM {0}";
    protected readonly static string[] updateColumns = new[] { nameof(EntityBaseDetails.ModifiedBy), nameof(EntityBaseDetails.ModifiedOn) };
    protected readonly static string[] insertColumns = new[] { nameof(EntityBaseDetails.CreatedBy), nameof(EntityBaseDetails.CreatedOn) };
    protected static List<string> columnsToUpdate = new List<string>();
    protected readonly string connectionString;
    protected readonly Dictionary<string, string> columnNames;
    protected readonly Dictionary<string, string> insertQuery;
    protected readonly IEnumerable<PropertyInfo> properties;
    protected readonly Dictionary<string, string> updateQuery;
    protected readonly string tableName;
    protected readonly KeyValuePair<string, string> primaryProperty;

    public BaseSqlRepository(MSSQLOptions mssqlOptions)
    {
        this.mssqlOptions = mssqlOptions;

        Type type = typeof(TEntity);
        properties = type.GetProperties();
        columnNames = properties.ToDictionary((PropertyInfo property) => property.Name, (PropertyInfo property) => property.GetCustomAttribute<ColumnAttribute>()?.Name ?? property.Name);
        tableName = type.GetCustomAttribute<TableAttribute>()?.Name ?? type.Name;
        primaryProperty = new KeyValuePair<string, string>(nameof(EntityBaseDetails.Id), columnNames[nameof(EntityBaseDetails.Id)]);
        insertQuery = columnNames.Where(c => !updateColumns.Contains(c.Key) && c.Key != primaryProperty.Key).ToDictionary(x => x.Key, x => x.Value);
        updateQuery = columnNames.Where(c => !insertColumns.Contains(c.Key) && c.Key != primaryProperty.Key).ToDictionary(x => x.Key.ToLower(), x => x.Value);
    }

    public async Task<DbConnection> GetConnection()
    {
        var conn = new SqlConnection(mssqlOptions.GetConnectionString());
        await conn.OpenAsync();
        return conn;
    }


    public string Select
        => string.Format(
                select,
                string.Join(", ", columnNames.Select(kvp => kvp.Key == kvp.Value ? kvp.Value : $"{kvp.Value} AS \"{kvp.Key}\"").ToList()),
                tableName);

    public string Count
        => string.Format(
                count,
                tableName);


    public string Browse
        => string.Format(
                browse,
                string.Join(", ", columnNames.Select(kvp => kvp.Key == kvp.Value ? kvp.Value : $"{kvp.Value} AS \"{kvp.Key}\"").ToList()),
                tableName);


    public string Insert
        => string.Format(insert, tableName,
                string.Join(", ", insertQuery.Values),
                string.Join(", ", insertQuery.Keys.Select(propName => $"@{propName}")), $"@{primaryProperty.Key}");

    public string Update => string.Format(update, tableName, string.Join(", ", updateQuery.Select(u => $"{u.Value}=@{u.Key}")));

    public string Delete => string.Format(delete, tableName);
}
