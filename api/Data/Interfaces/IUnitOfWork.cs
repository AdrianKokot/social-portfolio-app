using Sociussion.Data.Models;
using Sociussion.Data.Models.Community;
using Sociussion.Data.Models.Discussion;
using Sociussion.Data.QueryParams;
using Sociussion.Data.Repositories;

namespace Sociussion.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICommunityRepository CommunityRepository { get; }
        // IRepository<Discussion, ulong> DiscussionRepository { get; }
        // IGenericRepository<ApplicationUser, string> UserRepository { get; }
    }
}
