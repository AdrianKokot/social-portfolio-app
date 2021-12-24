using Sociussion.Application.Comments;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Services;

public interface ICommentService
{
    IQueryable<Comment> Get(ulong id);
    IQueryable<Comment> GetAll();
    IQueryable<Comment> GetAll(CommentQueryParams queryParams);
    Task<Comment> CreateFrom(CreateCommentModel createModel, ulong userId);
    Task<CommentViewModel> CreateFromAndGetVm(CreateCommentModel createModel, ulong userId);
    Task<Comment> Update(ulong entityId, UpdateCommentModel updateModel);

    Task<CommentViewModel> GetVm(ulong id);

    IQueryable<CommentViewModel> GetAllVm(CommentQueryParams queryParams);
    Task<bool> Delete(ulong id);
}