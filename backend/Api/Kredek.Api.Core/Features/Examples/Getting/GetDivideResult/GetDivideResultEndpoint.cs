using Kredek.Api.Common.Dtos.Utils;
using Kredek.Api.Common.Abstraction;
using Kredek.Api.Common.Extensions;
using Kredek.Api.Core.Features.Examples.Getting.GetDivide.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Kredek.Api.Core.Features.Examples.Getting.GetDivide;

internal class GetDivideResultEndpoint
    : FeatureEndpoint<Results<Ok<GetDivideResultResponse>, BadRequest<ErrorResponseDto>>, GetDivideResultRequest>
{
    public override void Configure(RouteHandlerBuilder builder)
        => builder.WithSummary("Divides the dividend by the divisor")
            .WithValidation<GetDivideResultRequest>();

    public override Task<Results<Ok<GetDivideResultResponse>, BadRequest<ErrorResponseDto>>> HandleAsync(
        [AsParameters] GetDivideResultRequest request, 
        CancellationToken ct = default)
    {
        var quotient = request.Dividend / request.Divisor;
        var remainder = request.Dividend % request.Divisor;
        var response = new GetDivideResultResponse(quotient, remainder);

        return Task.FromResult<Results<Ok<GetDivideResultResponse>, BadRequest<ErrorResponseDto>>>(
            TypedResults.Ok(response));
    }
}