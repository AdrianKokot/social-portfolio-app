using System.Threading.Tasks;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Community;
using Sociussion.Data.QueryParams;

namespace Sociussion.Data.Repositories
{
    public interface ICommunityRepository : IRepository<Community, ulong, CommunityParams>
    {
        Task<bool> AddMember(ulong communityId, string userId);
        Task<bool> RemoveMember(ulong communityId, string userId);
    }
}
