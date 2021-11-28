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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Community>()
                .HasOne<ApplicationUser>(s => s.Owner)
                .WithMany(u => u.OwnedCommunities)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
