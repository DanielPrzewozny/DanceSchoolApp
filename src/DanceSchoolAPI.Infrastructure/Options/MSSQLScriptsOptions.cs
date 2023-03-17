
using DanceSchoolAPI.Common.Options;

namespace DanceSchoolAPI.Infrastructure.Options;

public class MSSQLScriptsOptions : IOptions
{
    public string SectionKey => "MSSQLScripts";

    public string SchemaPath { get; set; }
    public string InitPath { get; set; }
    public string ScriptsPath { get; set; }
}
