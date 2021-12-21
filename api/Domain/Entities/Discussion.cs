using System.ComponentModel.DataAnnotations;
using Sociussion.Domain.Common;
using Sociussion.Domain.ValueObjects;

namespace Sociussion.Domain.Entities;

public class Discussion : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime? LastActive { get; set; } = null;
    public VoteScore VoteScore { get; set; } = new VoteScore();
    
    public ApplicationUser Author { get; set; }
    public ulong? AuthorId { get; set; }

    public Community Community { get; set; }
    public ulong CommunityId { get; set; }

    public ICollection<Comment> Comments { get; set; }
    public ulong CommentCount { get; set; } = 0;

    public ICollection<ApplicationUser> SavedBy { get; set; }
}