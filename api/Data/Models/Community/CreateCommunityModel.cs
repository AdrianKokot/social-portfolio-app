using System.ComponentModel.DataAnnotations;

namespace Sociussion.Data.Models.Community
{
    public class CreateCommunityModel
    {
        [Required] [MaxLength(255)] public string Name { get; set; }
    }
}
