using Kredek.Api.Common;
using Kredek.Api.Common.Extensions;
using Kredek.Api.Core.Features.Examples.Getting.GetDivide;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Kredek.Api.Core.Features.Examples;

public static class Examples
{
    public static RouteGroupBuilder MapExampleEndpoints(this WebApplication app)
    {
        var group = app.MapEndpointGroup(nameof(Examples));

        group.MapEndpoint<GetDivideResultEndpoint>(HttpVerbs.Get, "/divide");

        return group;
    }
}
