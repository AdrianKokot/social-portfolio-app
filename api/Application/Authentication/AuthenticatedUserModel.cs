namespace Sociussion.Application.Authentication;

public class AuthenticatedUserModel 
{
    public ulong Id { get; set; }
    public string Token { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
}