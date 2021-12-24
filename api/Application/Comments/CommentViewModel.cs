using AutoMapper;
using Sociussion.Application.Common.Mappings;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Comments;

public class CommentViewModel : IMapFrom<Comment>
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;

    public int AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;

    public int DiscussionId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public long VotesUp { get; set; }
    public long VotesDown { get; set; }
    public long Score { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Comment, CommentViewModel>();
    }
}