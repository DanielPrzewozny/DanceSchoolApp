
namespace DanceSchoolAPI.Models.Options;

public class MSSQLOptions : IOptions
{
    public string SectionKey => "MSSQL";

    public string Address { get; set; }
    public string Port { get; set; }
    public string Database { get; set; }
    public string User { get; set; }
    public string Password { get; set; }

    public string GetConnectionString()
        => $"Server={Address}; " +
        $"Port={Port}; Database={Database}; " +
        $"User Id={User}; " +
        $"Password={Password};";
}
