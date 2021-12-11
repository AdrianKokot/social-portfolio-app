using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Comment;
using Sociussion.Data.QueryParams;
using Sociussion.Data.Repositories;

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

                return CreatedAtAction(nameof(GetEntity), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
