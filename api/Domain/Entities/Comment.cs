using Sociussion.Domain.Common;

namespace Sociussion.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;

    public int VotesUp { get; set; } = 0;
    public int VotesDown { get; set; } = 0;
    
    public ApplicationUser Author { get; set; }
    public int? AuthorId { get; set; }

    public Discussion Discussion { get; set; }
    public int DiscussionId { get; set; }

    public ICollection<ApplicationUser> SavedBy { get; set; }
}