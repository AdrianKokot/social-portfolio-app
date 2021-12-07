using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Discussion;
using Sociussion.Data.QueryParams;

namespace Sociussion.Data.Repositories
{
    public interface IDiscussionRepository : IRepository<Discussion, ulong, DiscussionParams>
    {

    }
}
