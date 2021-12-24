namespace Sociussion.Application.Common.QueryParams;

public class DiscussionQueryParams : QueryParams
{
    public int? CommunityId { get; set; }
    public new string OrderBy { get; set; } = "CreatedAt desc";
}