namespace Sociussion.Data.QueryParams
{
    public class CommentParams : PaginationParams
    {
        public ulong? DiscussionId { get; set; }
    }
}
