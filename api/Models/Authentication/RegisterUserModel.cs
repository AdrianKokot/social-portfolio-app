using System.ComponentModel.DataAnnotations;

namespace Sociussion.Models.Authentication
{
    public record RegisterUserModel
    {
        [EmailAddress] [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}
