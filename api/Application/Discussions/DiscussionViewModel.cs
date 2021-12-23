using AutoMapper;
using Sociussion.Application.Common.Mappings;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Discussions;

public class DiscussionViewModel : IMapFrom<Discussion>
{
    public ulong Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime? LastActive { get; set; }
    public ulong? AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public ulong CommunityId { get; set; }
    public ulong CommentCount { get; set; }
    public long VotesUp { get; set; }
    public long VotesDown { get; set; }
    public long Score { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Discussion, DiscussionViewModel>();
    }
}