using System.ComponentModel.DataAnnotations;

namespace Sociussion.Application.Communities;

public class UpdateCommunityModel
{
    [Required] [MaxLength(255)] public string Name { get; set; } = string.Empty;
    [Required] [MaxLength(512)] public string Description { get; set; } = string.Empty;
}