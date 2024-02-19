using FluentValidation;
using Kredek.Api.Common.Dtos.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Kredek.Api.Common.Extensions;

public static class RouteHandlerBuilderExtensions
{
    public static RouteHandlerBuilder WithValidation<T>(
        this RouteHandlerBuilder builder)
        where T : class
    {
        builder.AddEndpointFilter(
            async (context, next) =>
            {
                var parameter = context.Arguments.OfType<T>().FirstOrDefault();
                var validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<T>>();

                if (parameter is null || validator is null)
                    return await next(context);

                var result = await validator.ValidateAsync(parameter);

                if (!result.IsValid)
                {
                    var errors = result.Errors
                        .Select(e => new ErrorResultDto(e.ErrorCode, e.ErrorMessage));
                        
                    return Results.BadRequest(new ErrorResponseDto(errors));
                }

                return await next(context);
            });

        return builder;
    }
}
