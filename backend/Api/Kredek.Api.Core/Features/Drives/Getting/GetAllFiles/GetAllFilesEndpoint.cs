using Kredek.Api.Common.Constants;
using Kredek.Api.Common.Dtos.Utils;
using Kredek.Api.Common.Abstraction;
using Kredek.Api.Core.Interfaces.Services;
using Kredek.Api.Core.Features.Drives.Getting.GetAllFiles.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kredek.Api.Core.Features.Drives.Getting.GetAllFiles;

internal class GetAllFilesEndpoint
    : FeatureEndpoint<Results<Ok<GetAllFilesResponse>, BadRequest<ErrorResponseDto>>, IGoogleDriveService>
{
    public override void Configure(RouteHandlerBuilder builder)
    {
        builder.WithSummary("Gets all files from Google Drive")
            .RequireAuthorization();
    }

    public async override Task<Results<Ok<GetAllFilesResponse>, BadRequest<ErrorResponseDto>>> HandleAsync(
        [FromServices] IGoogleDriveService googleDriveService, 
        CancellationToken cancellationToken = default)
    {
        var driveFiles = await googleDriveService.GetAllFilesAsync(cancellationToken);

        if (driveFiles is null)
        {
            var error = ErrorResponseDto.FromError(
                ErrorCodes.UnableToGetFiles, 
                "Failed to get files from Google Drive");
                
            return TypedResults.BadRequest(error);
        }

        var fileList = driveFiles.Files.ToList();

        var response = new GetAllFilesResponse
        {
            TotalCount = fileList.Count,
            Files = fileList.Select(f => new GetAllFilesResponseFileDto
            {
                Id = f.Id,
                Name = f.Name,
            })
        };

        return TypedResults.Ok(response);
    }
}