using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Kredek.Api.Common.Extensions;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapEndpointGroup(
        this WebApplication app, 
        string name, 
        int version = 1)
    {
        var group = app.MapGroup($"/api/v{version}/{name.ToLowerInvariant()}")
            .WithOpenApi()
            .WithTags(name);
        return group;
    }
}