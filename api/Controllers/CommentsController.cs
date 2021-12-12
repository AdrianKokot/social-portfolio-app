using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Comment;
using Sociussion.Data.QueryParams;
using Sociussion.Data.Repositories;
using Sociussion.Extensions;

namespace Sociussion.Controllers
{
    [Authorize]
    public class CommentsController : RepositoryApiController<ICommentRepository, Comment, ulong, CommentParams>
    {
        public CommentsController(IUnitOfWork unitOfWork) : base(unitOfWork.CommentRepository)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentModel createModel)
        {
            var currentUserId = User.Identity.GetUserId();

            var model = new Comment()
            {
                Content = createModel.Content, AuthorId = currentUserId, DiscussionId = createModel.DiscussionId
            };

            try
            {
                await Repository.Add(model);

                return CreatedAtAction(nameof(GetEntity), new {id = model.Id}, new
                {
                    model.Id
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public override async Task<IActionResult> GetEntities(CommentParams paginationParams)
        {
            var result = await Repository.GetAll(paginationParams);

            Response.AddNavigationHeaders(result.Metadata);
            
            return Ok(result.Select(c => new
            {
                c.Id,
                c.Content,
                c.AuthorId,
                c.DiscussionId,
                c.CreatedAt,
                c.EditedAt,
                c.VotesUp,
                c.VotesDown,
                Score = c.VotesUp - c.VotesDown,
                AuthorName = c.Author.Name
            }));
        }
    }
}
