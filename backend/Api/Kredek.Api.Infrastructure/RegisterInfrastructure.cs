using Kredek.Api.Common;
using Kredek.Api.Core.Interfaces.Factories;
using Kredek.Api.Core.Interfaces.Services;
using Kredek.Api.Infrastructure.Factories;
using Kredek.Api.Infrastructure.Services;
using Kredek.Api.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Kredek.Api.Common.Constants;
using Kredek.Api.Common.Settings;

namespace Kredek.Api.Infrastructure;

public static class RegisterInfrastructure
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Factories
        services.AddSingleton<IGoogleTokenFactory, GoogleTokenFactory>();

        // Services
        services.AddScoped<IGoogleDriveService, GoogleDriveService>();

        // Settings
        services.AddSettingsWithValidation<GoogleAuthSettings>(SectionNames.GoogleAuth);
        services.AddSettingsWithValidation<GoogleApiSettings>(SectionNames.GoogleApi);

        // HttpClients
        services.AddHttpClient(HttpClientNames.GoogleAuth, client =>
        {
            var googleAuthSettings = configuration.GetSettings<GoogleAuthSettings>(SectionNames.GoogleAuth);
            client.BaseAddress = new Uri(googleAuthSettings.TokenUri);
        });
        services.AddHttpClient(HttpClientNames.GoogleApi, client =>
        {
            var googleApiSettings = configuration.GetSettings<GoogleApiSettings>(SectionNames.GoogleApi);
            client.BaseAddress = new Uri(googleApiSettings.BaseUri);
        });

        // Other
        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
