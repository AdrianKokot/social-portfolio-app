using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Collections;
using Sociussion.Data.Interfaces;
using Sociussion.Helpers;

namespace Sociussion.Controllers
{
    public abstract class GenericApiController<TEntity, TEntityKey> : ApiController where TEntity : class
    {
        internal readonly IRepository<TEntity, TEntityKey> Repository;

        protected GenericApiController(IRepository<TEntity, TEntityKey> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetEntities([FromQuery] PaginationParams paginationParams)
        {
            var result = await Repository.GetAll(paginationParams);

            Response.Headers.Add("X-Pagination", AppJsonSerializer.Serialize(result.Metadata));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetEntity(TEntityKey id)
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
