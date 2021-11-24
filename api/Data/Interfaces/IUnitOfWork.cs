using Sociussion.Data.Models.Community;
using Sociussion.Data.Models.Discussion;

namespace Sociussion.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Community, ulong> CommunityRepository { get; }
        IGenericRepository<Discussion, ulong> DiscussionRepository { get; }
    }
}
