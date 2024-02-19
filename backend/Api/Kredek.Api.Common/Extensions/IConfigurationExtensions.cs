using Microsoft.Extensions.Configuration;

namespace Kredek.Api.Common.Extensions;

public static class IConfigurationExtensions
{
    public static T GetSettings<T>(this IConfiguration configuration, string sectionName)
    {
        var settings = configuration.GetSection(sectionName).Get<T>();

        ArgumentNullException.ThrowIfNull(settings, nameof(settings));

        return settings;
    }
}