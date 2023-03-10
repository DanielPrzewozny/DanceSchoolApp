using Microsoft.Extensions.Hosting;

namespace DanceSchoolAPI.Extensions;

public static class Environments
{
    public static readonly string Development = "Development";
    public static readonly string Docker = "Docker";
    public static readonly string Staging = "Staging";
    public static readonly string Production = "Production";
}
