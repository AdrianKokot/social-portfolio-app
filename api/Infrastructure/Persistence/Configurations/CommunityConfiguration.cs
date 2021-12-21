using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sociussion.Domain.Entities;

namespace Sociussion.Infrastructure.Persistence.Configurations;

public class CommunityConfiguration : IEntityTypeConfiguration<Community>
{
    public void Configure(EntityTypeBuilder<Community> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(512)
            .IsRequired();

        builder.Property(x => x.PhotoUrl)
            .HasMaxLength(512);
    }
}