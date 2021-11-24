using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sociussion.Data.Collections;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Community;
using Sociussion.Helpers;

namespace Sociussion.Controllers
{
    public class CommunitiesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommunitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommunities([FromQuery] PaginationParams paginationParams)
        {
            var result = await _unitOfWork.CommunityRepository.GetAll(paginationParams);


            Response.Headers.Add("X-Pagination", AppJsonSerializer.Serialize(result.Metadata));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommunity(string id)
        {
            try
            {
                return Ok(await _unitOfWork.CommunityRepository.Get(id));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommunity(CreateCommunityModel createModel)
        {
            var model = new Community() {Name = createModel.Name};

            try
            {
                await _unitOfWork.CommunityRepository.Add(model);

                return CreatedAtAction(nameof(GetCommunity), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
