using Sociussion.Domain.Common;

namespace Sociussion.Domain.Entities;

public class Discussion : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime? LastActive { get; set; } = null;
    public int VotesUp { get; set; } = 0;
    public int VotesDown { get; set; } = 0;
    
    public ApplicationUser Author { get; set; }
    public int? AuthorId { get; set; }

    public Community Community { get; set; }
    public int CommunityId { get; set; }

    public ICollection<Comment> Comments { get; set; }
    public int CommentCount { get; set; } = 0;

    public ICollection<ApplicationUser> SavedBy { get; set; }
}