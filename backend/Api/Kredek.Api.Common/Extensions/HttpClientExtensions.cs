using System.Net.Http.Headers;

namespace Kredek.Api.Common.Extensions;

public static class HttpClientExtensions
{
    public static void AddBearerToken(this HttpClient client, string token)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}
