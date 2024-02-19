using FluentValidation;
using Kredek.Api.Common;
using Kredek.Api.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Kredek.Api.Common.Settings;
using Kredek.Api.Core.Features.Examples.Getting.GetDivide.Contracts;

namespace Kredek.Api.Core;

public static class RegisterCore
{
    public static IServiceCollection AddCore(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Cors
        services.AddCors(options =>
        {
            var corsSettings = configuration.GetSettings<CorsSettings>(SectionNames.Cors);
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins(corsSettings.AllowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => 
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });

        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<GetDivideResultRequestValidator>(includeInternalTypes: true);
        ValidatorOptions.Global.LanguageManager.Enabled = false;

        return services;
    }
}
