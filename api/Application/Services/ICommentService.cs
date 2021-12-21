using Sociussion.Application.Comments;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Services;

public interface ICommentService
{
    IQueryable<Comment> Get(ulong id);
    IQueryable<Comment> GetAll();
    Task<Comment> CreateFrom(CreateCommentModel createModel, ulong getUserId);
}