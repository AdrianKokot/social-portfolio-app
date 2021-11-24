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
        protected readonly IGenericRepository<TEntity, TEntityKey> _repository;

        protected GenericApiController(IGenericRepository<TEntity, TEntityKey> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEntities([FromQuery] PaginationParams paginationParams)
        {
            var result = await _repository.GetAll(paginationParams);

            Response.Headers.Add("X-Pagination", AppJsonSerializer.Serialize(result.Metadata));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntity(TEntityKey id)
        {
            try
            {
                return Ok(await _repository.Get(id));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
