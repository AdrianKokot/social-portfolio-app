using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sociussion.Domain.Entities;

namespace Sociussion.Infrastructure.Persistence.Configurations;

public class DiscussionConfiguration : IEntityTypeConfiguration<Discussion>
{
    public void Configure(EntityTypeBuilder<Discussion> builder)
    {
        builder.OwnsOne(x => x.VoteScore);

        builder.Property(x => x.Title)
            .HasMaxLength(255)
            .IsRequired();
    }
}