using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Community;

namespace Sociussion.Controllers
{
    public class CommunityController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommunityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommunities()
        {
            return Ok(await _unitOfWork.CommunityRepository.GetAll());
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
