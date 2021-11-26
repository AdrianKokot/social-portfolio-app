using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Community;

namespace Sociussion.Controllers
{
    public class CommunitiesController : GenericApiController<Community, ulong>
    {
        public CommunitiesController(IUnitOfWork unitOfWork)
            : base(unitOfWork.CommunityRepository)
        {
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

                return CreatedAtAction(nameof(GetEntity), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
