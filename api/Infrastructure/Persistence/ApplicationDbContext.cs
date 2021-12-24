using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Common.Interfaces;
using Sociussion.Domain.Abstractions;
using Sociussion.Domain.Entities;

namespace Sociussion.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    private readonly IDateTime _dateTime;
    
    public DbSet<Community> Communities { get; set; }
    public DbSet<Discussion> Discussions { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public ApplicationDbContext(DbContextOptions options, IDateTime dateTime)
        : base(options)
    {
        _dateTime = dateTime;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Seed();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = _dateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}