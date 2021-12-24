using Sociussion.Application.Comments;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Services;

public interface ICommentService
{
    Task<Comment> Get(int id);
    IQueryable<Comment> GetAll();
    IQueryable<Comment> GetAll(CommentQueryParams queryParams);
    Task<Comment> CreateFrom(CreateCommentModel createModel, int userId);
    Task<CommentViewModel> CreateFromAndGetVm(CreateCommentModel createModel, int userId);
    Task<Comment> Update(int entityId, UpdateCommentModel updateModel);

    Task<CommentViewModel> GetVm(int id);

    IQueryable<CommentViewModel> GetAllVm(CommentQueryParams queryParams);
    Task<bool> Delete(int id);
}