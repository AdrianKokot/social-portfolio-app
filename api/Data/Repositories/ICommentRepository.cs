using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Comment;
using Sociussion.Data.QueryParams;

namespace Sociussion.Data.Repositories
{
    public interface ICommentRepository : IRepository<Comment, ulong, CommentParams>
    {
    }
}
