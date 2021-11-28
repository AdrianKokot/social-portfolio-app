using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Community;
using Sociussion.Data.QueryParams;
using Sociussion.Helpers;

namespace Sociussion.Controllers
{
    public class CommunitiesController : GenericApiController<Community, ulong, CommunityParams>
    {
        public CommunitiesController(IUnitOfWork unitOfWork)
            : base(unitOfWork.CommunityRepository)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetCommunities([FromQuery] CommunityParams paginationParams)
        {
            return await base.GetEntities(paginationParams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommunity(ulong id)
        {
            return await base.GetEntity(id);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommunityModel createModel)
        {
            var currentUserId = User.Identity.GetUserId();

            var model = new Community()
            {
                Name = createModel.Name, Description = createModel.Description, OwnerId = currentUserId
            };

            try
            {
                await Repository.Add(model);

                return CreatedAtAction(nameof(GetCommunity), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
