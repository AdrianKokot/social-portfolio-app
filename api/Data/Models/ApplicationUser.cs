using Microsoft.AspNetCore.Identity;

namespace Sociussion.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
