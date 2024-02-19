using System.ComponentModel.DataAnnotations;

namespace Kredek.Api.Common.Settings;

public class CorsSettings
{
    [Required]
    public string[] AllowedOrigins { get; set; } = default!;
}
