using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Interfaces;
using Sociussion.Data.QueryParams;
using Sociussion.Extensions;

namespace Sociussion.Controllers
{
    public abstract class RepositoryApiController<TRepository, TEntity, TEntityId, TParams> : ApiController
        where TRepository : IRepository<TEntity, TEntityId, TParams>
        where TEntity : class
        where TParams : PaginationParams
    {
        internal readonly TRepository Repository;

        protected RepositoryApiController(TRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetEntities([FromQuery] TParams paginationParams)
        {
            var result = await Repository.GetAll(paginationParams);

            Response.AddNavigationHeaders(result.Metadata);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetEntity(TEntityId id)
        {
            var entity = await Repository.Get(id);

            if (entity is null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
    }
}
