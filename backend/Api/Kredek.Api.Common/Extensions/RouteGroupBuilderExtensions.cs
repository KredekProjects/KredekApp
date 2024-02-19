using Kredek.Api.Common.Abstraction;
using Microsoft.AspNetCore.Routing;

namespace Kredek.Api.Common.Extensions;

public static class RouteGroupBuilderExtensions
{
    public static RouteGroupBuilder MapEndpoint<TEndpoint>(
        this RouteGroupBuilder app, 
        HttpVerbs verb,
        string route) 
        where TEndpoint : IFeatureEndpoint, new()
    {
        var endpoint = new TEndpoint();

        endpoint.AddRoute(app, verb, route);

        return app;
    }
}