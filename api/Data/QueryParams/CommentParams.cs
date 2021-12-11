namespace Sociussion.Data.QueryParams
{
    public class CommentParams : PaginationParams
    {
        public ulong? CommunityId { get; set; }
    }
}
