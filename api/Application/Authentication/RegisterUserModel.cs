using System.ComponentModel.DataAnnotations;

namespace Sociussion.Application.Authentication;

public class RegisterUserModel : LoginUserModel
{
    [Required]
    [MaxLength(128)]
    [MinLength(5)]
    public string Name { get; set; } = string.Empty;

    [Compare(nameof(Password), ErrorMessage = "Password and its confirmation don't match.")]
    [Required]
    public string PasswordConfirmation { get; set; } = string.Empty;
}