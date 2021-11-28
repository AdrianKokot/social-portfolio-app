namespace Sociussion.Data.Models.Authentication
{
    internal record AuthenticatedUserModel
    {
        public string Id { get; set; }
        public string Token { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }
    }
}
