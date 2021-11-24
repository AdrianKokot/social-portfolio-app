using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Models;
using Sociussion.Data.Models.Community;

namespace Sociussion.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Community> Communities { get; set; }
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
