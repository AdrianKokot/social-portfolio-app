using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Discussions;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Services;

public interface IDiscussionService
{
    Task<Discussion> Get(int id);
    IQueryable<Discussion> GetAll();
    IQueryable<Discussion> GetAll(DiscussionQueryParams queryParams);
    Task<Discussion> CreateFrom(CreateDiscussionModel createModel, int getUserId);
    Task<DiscussionViewModel> CreateFromAndGetVm(CreateDiscussionModel createModel, int userId);
    IQueryable<DiscussionViewModel> GetAllVm(DiscussionQueryParams queryParams);
    Task<DiscussionViewModel> GetVm(int id);
    Task<Discussion> Update(int id, UpdateDiscussionModel updateModel);
    Task<bool> Delete(int id);
}