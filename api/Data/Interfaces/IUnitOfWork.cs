using Sociussion.Data.Models;
using Sociussion.Data.Models.Community;
using Sociussion.Data.Models.Discussion;

namespace Sociussion.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Community, ulong> CommunityRepository { get; }
        IRepository<Discussion, ulong> DiscussionRepository { get; }
        // IGenericRepository<ApplicationUser, string> UserRepository { get; }
    }
}
