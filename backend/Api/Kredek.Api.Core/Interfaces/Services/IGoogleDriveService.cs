using Kredek.Api.Common.Dtos.Google;

namespace Kredek.Api.Core.Interfaces.Services;

public interface IGoogleDriveService
{
    Task<GoogleDriveFileListDto?> GetAllFilesAsync(CancellationToken ct = default);
}
