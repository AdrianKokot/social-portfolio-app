using Sociussion.Domain.Common;
using Sociussion.Domain.ValueObjects;

namespace Sociussion.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;

    public VoteScore VoteScore { get; set; } = new VoteScore();
    
    public ApplicationUser Author { get; set; }
    public ulong? AuthorId { get; set; }

    public Discussion Discussion { get; set; }
    public ulong DiscussionId { get; set; }

    public ICollection<ApplicationUser> SavedBy { get; set; }
}