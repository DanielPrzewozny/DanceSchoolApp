using DanceSchoolAPI.Common.Models.Options;
using Microsoft.Extensions.Configuration;

namespace DanceSchoolAPI.Common.Extensions;
public static class ConfigurationExtensions
{
    public static TOptions GetOptions<TOptions>(this IConfiguration configuration)
        where TOptions : IOptions, new()
    {
        var options = new TOptions();
        configuration.GetSection(options.SectionKey).Bind(options);
        return options;
    }
}
