using System.ComponentModel.DataAnnotations;

namespace Kredek.Api.Common.Settings;

public class GoogleApiSettings
{
    [Required]
    public string BaseUri { get; set; } = default!;
}