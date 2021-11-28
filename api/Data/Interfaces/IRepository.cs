using System.Threading.Tasks;
using Sociussion.Data.Collections;
using Sociussion.Data.QueryParams;

namespace Sociussion.Data.Interfaces
{
    public interface IRepository<TEntity, in TEntityId> : IRepository<TEntity, TEntityId, PaginationParams>
        where TEntity : class
    {
        
    }
    public interface IRepository<TEntity, in TEntityId, in TParams> where TEntity : class where TParams : PaginationParams
    {
        Task<TEntity> Get(TEntityId id);
        Task<PaginatedList<TEntity>> GetAll(TParams paginationParams);
        Task<TEntity> Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
