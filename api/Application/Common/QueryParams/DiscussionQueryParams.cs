namespace Sociussion.Application.Common.QueryParams;

public class DiscussionQueryParams : QueryParams
{
    public int? CommunityId { get; set; }

    public DiscussionQueryParams()
    {
        OrderBy = "CreatedAt asc";
    }
}