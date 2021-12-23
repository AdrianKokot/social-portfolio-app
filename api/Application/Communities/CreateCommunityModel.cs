using System.ComponentModel.DataAnnotations;

namespace Sociussion.Application.Communities;

public class CreateCommunityModel
{
    [Required] [MaxLength(255)] public string Name { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;
}