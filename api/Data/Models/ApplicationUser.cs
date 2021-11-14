using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Sociussion.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
