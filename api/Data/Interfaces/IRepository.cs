using System.Threading.Tasks;
using Sociussion.Data.Collections;

namespace Sociussion.Data.Interfaces
{
    public interface IRepository<TEntity, in TEntityId> where TEntity : class
    {
        Task<TEntity> Get(TEntityId id);
        Task<PaginatedList<TEntity>> GetAll(PaginationParams paginationParams);
        Task<TEntity> Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
