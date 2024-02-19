using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Kredek.Api.Common.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddSettingsWithValidation<T>(
        this IServiceCollection services,
        string section)
        where T : class
    {
        services
            .AddOptionsWithValidateOnStart<T>()
            .BindConfiguration(section)
            .ValidateDataAnnotations();

        return services;
    }

    public static IdentityBuilder AddAuth<TUser>(
        this IServiceCollection services)
        where TUser : IdentityUser, new()
    {
        services.AddAuthorizationBuilder();
        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);
            
        var builder = services.AddIdentityCore<TUser>();

        return builder;
    }
}
