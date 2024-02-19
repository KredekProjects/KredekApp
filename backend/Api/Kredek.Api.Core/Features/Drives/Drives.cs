using Kredek.Api.Common;
using Kredek.Api.Common.Extensions;
using Kredek.Api.Core.Features.Drives.Getting.GetAllFiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Kredek.Api.Core.Features.Drives;

public static class Drives
{
    public static RouteGroupBuilder MapDriveEndpoints(this WebApplication app)
    {
        var group = app.MapEndpointGroup(nameof(Drives));

        group.MapEndpoint<GetAllFilesEndpoint>(HttpVerbs.Get, "/files");

        return group;
    } 
}