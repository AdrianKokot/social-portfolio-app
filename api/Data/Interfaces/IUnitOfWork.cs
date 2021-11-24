using Sociussion.Data.Models.Community;

namespace Sociussion.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Community, string> CommunityRepository { get; }
    }
}
