namespace Kredek.Api.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class RegisterPersistance
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<KredekDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetSection(Kredek.Api.Common.Constants.DBConnectionStrings.DefaultConnection));
        });

        return services;
    }
}