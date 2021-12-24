using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Sociussion.Domain.Abstractions;

namespace Sociussion.Domain.Entities;

public class ApplicationUser : IdentityUser<int>, IBaseEntity
{
    public string Name { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    
    public ICollection<Community> OwnedCommunities { get; set; }
    public ICollection<Community> MemberOfCommunities { get; set; }

    public ICollection<Comment> WrittenComments { get; set; }
    public ICollection<Comment> SavedComments { get; set; }

    public ICollection<Discussion> WrittenDiscussions { get; set; }
    public ICollection<Discussion> SavedDiscussions { get; set; }
}