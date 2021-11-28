using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Community;
using Sociussion.Data.QueryParams;
using Sociussion.Data.Repositories;

namespace Sociussion.Controllers
{
    [Authorize]
    public class
        CommunitiesController : RepositoryApiController<ICommunityRepository, Community, ulong, CommunityParams>
    {
        public CommunitiesController(IUnitOfWork unitOfWork)
            : base(unitOfWork.CommunityRepository)
        {
        }

        [HttpPost("{id}/join")]
        public async Task<IActionResult> JoinCommunity(ulong id)
        {
            try
            {
                if (await Repository.AddMember(id, User.Identity.GetUserId()))
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                // ignored
            }

            return NotFound();
        }

        [HttpDelete("{id}/leave")]
        public async Task<IActionResult> LaveCommunity(ulong id)
        {
            try
            {
                if (await Repository.RemoveMember(id, User.Identity.GetUserId()))
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                // ignored
            }

            return NotFound();
        }

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
