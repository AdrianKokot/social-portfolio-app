using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Discussion;
using Sociussion.Data.QueryParams;
using Sociussion.Data.Repositories;
using Sociussion.Extensions;

namespace Sociussion.Controllers
{
    [Authorize]
    public class
        DiscussionsController : RepositoryApiController<IDiscussionRepository, Discussion, ulong, DiscussionParams>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiscussionsController(IUnitOfWork unitOfWork) : base(unitOfWork.DiscussionRepository)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscussionModel createModel)
        {
            var currentUserId = User.Identity.GetUserId();

            if (await _unitOfWork.CommunityRepository.Get(createModel.CommunityId) is null)
            {
                return BadApiRequest(nameof(createModel.CommunityId), "Given community doesn't exist.");
            }

            var model = new Discussion()
            {
                Title = createModel.Title,
                CommunityId = createModel.CommunityId,
                AuthorId = currentUserId,
                Content = createModel.Content
            };

            try
            {
                await Repository.Add(model);

                return CreatedAtAction(nameof(GetEntity), new {id = model.Id}, new
                {
                    model.Id,
                    model.Content,
                    model.Title,
                    model.CommunityId
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public override async Task<IActionResult> GetEntities(DiscussionParams paginationParams)
        {
            var result = (await Repository.GetAll(paginationParams));

            Response.AddNavigationHeaders(result.Metadata);

            return Ok(
                result.Select(x => new
                {
                    x.Id,
                    x.Title,
                    x.VotesUp,
                    x.VotesDown,
                    Score = x.VotesUp - x.VotesDown,
                    x.Content,
                    x.CommunityId,
                    x.AuthorId,
                    AuthorName = x.Author.Name,
                    x.CreatedAt,
                    x.EditedAt,
                    x.CommentsCount
                })
            );
        }
    }
}
