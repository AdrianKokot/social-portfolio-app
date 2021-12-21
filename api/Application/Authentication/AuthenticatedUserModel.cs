namespace Sociussion.Application.Authentication;

public class AuthenticatedUserModel 
{
    public ulong Id { get; set; }
    public string Token { get; init; }
    public string Email { get; init; }
    public string Name { get; init; }
}