using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sociussion.Data.Interfaces
{
    public interface IGenericRepository<TEntity, in TEntityId> where TEntity : class
    {
        Task<TEntity> Get(TEntityId id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
