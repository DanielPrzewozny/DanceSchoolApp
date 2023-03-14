
using DanceSchoolAPI.Common.Options;

namespace DanceSchoolAPI.Infrastructure.Options;

public class MSSQLOptions : IOptions
{
    public string SectionKey => "MSSQL";

    public string Server { get; set; }
    public string Database { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public bool TrustServerCertificate { get; set; }

    public string GetConnectionString() => @$"Server={Server};Database={Database};User ID={User};Password={Password};TrustServerCertificate={TrustServerCertificate}";
}
