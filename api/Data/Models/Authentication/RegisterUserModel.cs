using System.ComponentModel.DataAnnotations;

namespace Sociussion.Data.Models.Authentication
{
    public record RegisterUserModel
    {
        [Required]
        [MaxLength(128)]
        [MinLength(5)]
        public string Name { get; set; }

        [EmailAddress] [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and its confirmation don't match.")]
        [Required]
        public string PasswordConfirmation { get; set; }
    }
}
