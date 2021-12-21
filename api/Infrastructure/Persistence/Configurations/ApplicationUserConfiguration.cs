using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sociussion.Domain.Entities;

namespace Sociussion.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        ConfigureRelationships(builder);

        builder.Property(x => x.Name)
            .HasMaxLength(64)
            .IsRequired();
    }

    private void ConfigureRelationships(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasMany(x => x.OwnedCommunities)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId);

        builder
            .HasMany(x => x.MemberOfCommunities)
            .WithMany(x => x.Members);

        builder
            .HasMany(x => x.WrittenComments)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId);

        builder
            .HasMany(x => x.WrittenDiscussions)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId);

        builder
            .HasMany(x => x.SavedComments)
            .WithMany(x => x.SavedBy);

        builder
            .HasMany(x => x.SavedDiscussions)
            .WithMany(x => x.SavedBy);
    }
}