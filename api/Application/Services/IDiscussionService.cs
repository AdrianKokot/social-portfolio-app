using Sociussion.Application.Discussions;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Services;

public interface IDiscussionService
{
    IQueryable<Discussion> Get(ulong id);
    IQueryable<Discussion> GetAll();
    Task<Discussion> CreateFrom(CreateDiscussionModel createModel, ulong getUserId);
}