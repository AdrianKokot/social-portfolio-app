using Sociussion.Data.Repositories;

namespace Sociussion.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICommunityRepository CommunityRepository { get; }
        IDiscussionRepository DiscussionRepository { get; }
        ICommentRepository CommentRepository { get; }
    }
}
