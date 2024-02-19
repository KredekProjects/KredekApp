namespace Kredek.Api.Common.Dtos.Utils;

public record ErrorResponseDto(IEnumerable<ErrorResultDto> Errors)
{
    public static ErrorResponseDto FromError(string code, string message) 
        => new([new ErrorResultDto(code, message)]);
};

public record ErrorResultDto(string Code, string Message);