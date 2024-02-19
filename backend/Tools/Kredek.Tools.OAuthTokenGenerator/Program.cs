using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services
    .AddOptionsWithValidateOnStart<GoogleAuthOptions>()
    .BindConfiguration("GoogleAuth")
    .ValidateDataAnnotations();

var app = builder.Build();

app.MapGet("/", () => "Hello Kredek! Go to /auth");

app.MapGet("/auth", (IOptions<GoogleAuthOptions> options) =>
{
    // https://developers.google.com/identity/protocols/oauth2/web-server#redirecting
    var url = $"{options.Value.AuthUri}" + 
        $"?client_id={options.Value.ClientId}" +
        $"&redirect_uri={options.Value.RedirectUri}" +
        $"&scope={options.Value.Scope}" +
        $"&access_type=offline" +
        $"&response_type=code";

    return Results.Redirect(url);
});

app.MapGet("/callback", async (
    [AsParameters] CallbackResponse response, 
    IHttpClientFactory clientFactory,
    IOptions<GoogleAuthOptions> options) =>
{
    if (response.Error is not null)
        return Results.BadRequest(response.Error);

    var client = clientFactory.CreateClient("GoogleAuth");

    // https://developers.google.com/identity/protocols/oauth2/web-server#exchange-authorization-code
    var tokenResponse = await client.PostAsync(options.Value.TokenUri, 
        new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["code"] = response.Code,
            ["client_id"] = options.Value.ClientId,
            ["client_secret"] = options.Value.ClientSecret,
            ["redirect_uri"] = options.Value.RedirectUri,
            ["grant_type"] = "authorization_code"
        }));

    if (!tokenResponse.IsSuccessStatusCode)
        return Results.BadRequest(await tokenResponse.Content.ReadAsStringAsync());

    var token = await tokenResponse.Content.ReadFromJsonAsync<TokenResponse>();

    return Results.Ok(token);
});

app.Run();

internal record GoogleAuthOptions
{
    [Required]
    public string ClientId { get; init; } = default!;

    [Required]
    public string ClientSecret { get; init; } = default!;

    [Required]
    public string AuthUri { get; init; } = default!;

    [Required]
    public string RedirectUri { get; init; } = default!;

    [Required]
    public string TokenUri { get; init; } = default!;

    [Required]
    public string Scope { get; init; } = default!;
}

internal record CallbackResponse(
    string Code,
    string Scope,
    string? Error
);

internal record TokenResponse(
    [property: JsonPropertyName("access_token")] string AccessToken,
    [property: JsonPropertyName("expires_in")] int ExpiresIn,
    [property: JsonPropertyName("token_type")] string TokenType,
    [property: JsonPropertyName("refresh_token")] string RefreshToken,
    [property: JsonPropertyName("scope")] string Scope
);