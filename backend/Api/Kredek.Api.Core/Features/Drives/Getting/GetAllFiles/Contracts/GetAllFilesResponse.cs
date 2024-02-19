namespace Kredek.Api.Core.Features.Drives.Getting.GetAllFiles.Contracts;
internal record GetAllFilesResponse
{
    public required int TotalCount { get; init; }
    public required IEnumerable<GetAllFilesResponseFileDto> Files { get; init; }
}

internal record GetAllFilesResponseFileDto
{
    public required string Id { get; init; }
    public required string Name { get; init; }
}