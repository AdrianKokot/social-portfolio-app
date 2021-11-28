using Sociussion.Data.Models;
using Sociussion.Data.Models.Community;
using Sociussion.Data.Models.Discussion;
using Sociussion.Data.QueryParams;

namespace Sociussion.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Community, ulong, CommunityParams> CommunityRepository { get; }
        // IRepository<Discussion, ulong> DiscussionRepository { get; }
        // IGenericRepository<ApplicationUser, string> UserRepository { get; }
    }
}
