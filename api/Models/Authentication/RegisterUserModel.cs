using System.ComponentModel.DataAnnotations;

namespace Sociussion.Models.Authentication
{
    public record RegisterUserModel
    {
        [Required]
        [MaxLength(255)]
        [MinLength(5)]
        public string Name { get; set; }

        [EmailAddress] [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Compare(nameof(Password))] [Required] public string PasswordConfirmation { get; set; }
    }
}
