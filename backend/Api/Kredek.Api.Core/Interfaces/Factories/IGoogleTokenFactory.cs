namespace Kredek.Api.Core.Interfaces.Factories;

public interface IGoogleTokenFactory
{
    Task<string> GetAccessTokenAsync(CancellationToken ct = default);
}