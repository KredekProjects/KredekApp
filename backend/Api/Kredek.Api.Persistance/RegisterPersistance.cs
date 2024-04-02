using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kredek.Api.Persistance;

public static class RegisterPersistance
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<KredekDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetValue<string>(Kredek.Api.Common.Constants.DBConnectionStrings.DefaultConnection));
        });

        return services;
    }
}