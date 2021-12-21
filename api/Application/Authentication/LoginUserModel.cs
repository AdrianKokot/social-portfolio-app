using System.ComponentModel.DataAnnotations;

namespace Sociussion.Application.Authentication;

public class LoginUserModel
{
    [EmailAddress] [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}