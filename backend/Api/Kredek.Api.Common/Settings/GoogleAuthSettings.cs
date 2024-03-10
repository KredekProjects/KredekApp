using System.ComponentModel.DataAnnotations;

namespace Kredek.Api.Common;

public class GoogleAuthSettings
{
    [Required]
    public string RefreshToken { get; set; } = default!;

    [Required]
    public string ClientId { get; set; } = default!;

    [Required]
    public string ClientSecret { get; set; } = default!;

    [Required]
    public string TokenUri { get; set; } = default!;
}