namespace Kredek.Api.Common.Dtos.Google;

public record GoogleDriveFileDto(
    string Id,
    string Name,
    string MimeType,
    string Kind
);