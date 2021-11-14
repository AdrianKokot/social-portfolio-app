using System.ComponentModel.DataAnnotations;

namespace Sociussion.Data.Models.Authentication
{
    public record LoginUserModel
    {
        [EmailAddress] [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}
