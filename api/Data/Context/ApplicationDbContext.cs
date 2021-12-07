using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Models;
using Sociussion.Data.Models.Community;
using Sociussion.Data.Models.Discussion;

namespace Sociussion.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Community> Communities { get; set; }
        public DbSet<Discussion> Discussions { get; set; }

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

            builder.Entity<Discussion>()
                .HasOne<ApplicationUser>(d => d.Author)
                .WithMany(u => u.OwnedDiscussions)
                .HasForeignKey(d => d.AuthorId);

            builder.Entity<Discussion>()
                .HasOne<Community>(d => d.Community)
                .WithMany(c => c.Discussions)
                .HasForeignKey(d => d.CommunityId);
        }
    }
}
