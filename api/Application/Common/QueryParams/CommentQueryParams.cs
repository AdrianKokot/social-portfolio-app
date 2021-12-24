namespace Sociussion.Application.Common.QueryParams;

public class CommentQueryParams : QueryParams
{
    public int? DiscussionId { get; set; }

    public CommentQueryParams()
    {
        OrderBy = "CreatedAt asc";
    }
}