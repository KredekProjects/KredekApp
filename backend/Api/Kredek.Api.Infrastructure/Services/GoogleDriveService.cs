using System.Net.Http.Json;
using Kredek.Api.Common.Constants;
using Kredek.Api.Common.Dtos.Google;
using Kredek.Api.Core.Interfaces.Factories;
using Kredek.Api.Core.Interfaces.Services;
using Kredek.Api.Common.Extensions;
using Microsoft.Extensions.Logging;

namespace Kredek.Api.Infrastructure.Services;

internal class GoogleDriveService : IGoogleDriveService
{
    private readonly IGoogleTokenFactory _googleTokenFactory;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<GoogleDriveService> _logger;

    public GoogleDriveService(
        IGoogleTokenFactory googleTokenFactory, 
        IHttpClientFactory httpClientFactory,
        ILogger<GoogleDriveService> logger)
    {
        _googleTokenFactory = googleTokenFactory;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<GoogleDriveFileListDto?> GetAllFilesAsync(CancellationToken ct = default)
    {
        var token = await _googleTokenFactory.GetAccessTokenAsync(ct);

        var httpClient = _httpClientFactory.CreateClient(HttpClientNames.GoogleApi);

        httpClient.AddBearerToken(token);

        _logger.LogInformation("Getting files from Google Drive");
        var response = await httpClient.GetAsync("/drive/v3/files", ct);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Failed to get files from Google Drive. Status code: {StatusCode}", response.StatusCode);
            return null;
        }

        var fileList = await response.Content.ReadFromJsonAsync<GoogleDriveFileListDto>(ct);
        
        if (fileList is null)
            _logger.LogError("Failed to deserialize Google Drive file list");

        return fileList;
    }
}