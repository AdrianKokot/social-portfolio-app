namespace Sociussion.Data.Models.Comment
{
    public class CreateCommentModel
    {
        public string Content { get; set; }
        public ulong CommunityId { get; set; }
    }
}
