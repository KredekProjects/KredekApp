using System.Net.Http.Json;
using Kredek.Api.Common;
using Kredek.Api.Common.Constants;
using Kredek.Api.Common.Dtos.Google;
using Kredek.Api.Core.Interfaces.Factories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kredek.Api.Infrastructure.Factories;

internal class GoogleTokenFactory : IGoogleTokenFactory
{
    private readonly GoogleAuthSettings _settings;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly TimeProvider _timeProvider;
    private readonly ILogger<GoogleTokenFactory> _logger;
    private readonly SemaphoreSlim _tokenLock = new(1, 1);
    private string _token = string.Empty;
    private DateTimeOffset _tokenExpiration = DateTimeOffset.MinValue;

    public GoogleTokenFactory(
        IOptions<GoogleAuthSettings> options, 
        IHttpClientFactory httpClientFactory,
        TimeProvider timeProvider,
        ILogger<GoogleTokenFactory> logger)
    {
        _settings = options.Value;
        _httpClientFactory = httpClientFactory;
        _timeProvider = timeProvider;
        _logger = logger;
    }

    public async Task<string> GetAccessTokenAsync(CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(_token) || _tokenExpiration < _timeProvider.GetUtcNow().AddMinutes(5))
        {
            await _tokenLock.WaitAsync(ct);
            try
            {
                if (string.IsNullOrEmpty(_token) || _tokenExpiration < _timeProvider.GetUtcNow().AddMinutes(5))
                {
                    var tokenResponse = await GetTokenAsync(ct);
                    _token = tokenResponse.AccessToken;
                    _tokenExpiration = _timeProvider.GetUtcNow()
                        .AddSeconds(tokenResponse.ExpiresIn);
                }
            }
            finally
            {
                _tokenLock.Release();
            }
        }

        return _token;
    }

    private async Task<GoogleTokenResponseDto> GetTokenAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("Getting Google tokens");

        var client = _httpClientFactory.CreateClient(HttpClientNames.GoogleAuth);

        // https://developers.google.com/identity/protocols/oauth2/web-server#offline
        var response = await client.PostAsync(_settings.TokenUri, 
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"] = _settings.ClientId,
                ["client_secret"] = _settings.ClientSecret,
                ["refresh_token"] = _settings.RefreshToken,
                ["grant_type"] = "refresh_token"
            }), ct);
        
        if (!response.IsSuccessStatusCode)
            throw new UnauthorizedAccessException(await response.Content.ReadAsStringAsync(ct));

        var tokenResponse = await response.Content.ReadFromJsonAsync<GoogleTokenResponseDto>(ct);
        ArgumentNullException.ThrowIfNull(tokenResponse, nameof(tokenResponse));

        return tokenResponse;
    }
}