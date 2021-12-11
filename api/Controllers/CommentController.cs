using Microsoft.AspNetCore.Authorization;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Comment;
using Sociussion.Data.QueryParams;
using Sociussion.Data.Repositories;

namespace Sociussion.Controllers
{
    [Authorize]
    public class CommentController : RepositoryApiController<ICommentRepository, Comment, ulong, CommentParams>
    {
        public CommentController(IUnitOfWork unitOfWork) : base(unitOfWork.CommentRepository)
        {
        }
    }
}
