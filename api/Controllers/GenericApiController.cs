using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Collections;
using Sociussion.Data.Interfaces;
using Sociussion.Data.QueryParams;
using Sociussion.Helpers;

namespace Sociussion.Controllers
{
    public abstract class GenericApiController<TEntity, TEntityKey, TParams> : ApiController where TEntity : class where TParams : PaginationParams
    {
        internal readonly IRepository<TEntity, TEntityKey, TParams> Repository;

        protected GenericApiController(IRepository<TEntity, TEntityKey, TParams> repository)
        {
            Repository = repository;
        }

        internal async Task<IActionResult> GetEntities(TParams paginationParams)
        {
            var result = await Repository.GetAll(paginationParams);

            Response.Headers.Add("X-Pagination", AppJsonSerializer.Serialize(result.Metadata));

            return Ok(result);
        }

        internal async Task<IActionResult> GetEntity(TEntityKey id)
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
