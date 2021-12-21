using System.ComponentModel.DataAnnotations;

namespace Sociussion.Application.Communities;

public class CreateCommunityModel
{
    [Required] [MaxLength(255)] public string Name { get; set; }
    [Required] public string Description { get; set; }
}