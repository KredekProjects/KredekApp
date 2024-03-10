namespace Kredek.Api.Common.Dtos.Google;

public record GoogleDriveFileListDto(
    string Kind,
    bool IncompleteSearch,
    IEnumerable<GoogleDriveFileDto> Files
);