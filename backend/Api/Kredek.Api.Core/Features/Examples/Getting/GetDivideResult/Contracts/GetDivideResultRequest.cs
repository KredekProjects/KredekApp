using FluentValidation;

namespace Kredek.Api.Core.Features.Examples.Getting.GetDivide.Contracts;

internal record class GetDivideResultRequest(int Dividend, int Divisor);

internal class GetDivideResultRequestValidator : AbstractValidator<GetDivideResultRequest>
{
    public GetDivideResultRequestValidator()
    {
        RuleFor(x => x.Divisor).NotEqual(0);
    }
}
