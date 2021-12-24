using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Discussions;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Services;

public interface IDiscussionService
{
    Task<Discussion> Get(ulong id);
    IQueryable<Discussion> GetAll();
    IQueryable<Discussion> GetAll(DiscussionQueryParams queryParams);
    Task<Discussion> CreateFrom(CreateDiscussionModel createModel, ulong getUserId);
    Task<DiscussionViewModel> CreateFromAndGetVm(CreateDiscussionModel createModel, ulong userId);
    IQueryable<DiscussionViewModel> GetAllVm(DiscussionQueryParams queryParams);
    Task<DiscussionViewModel> GetVm(ulong id);
    Task<Discussion> Update(ulong id, UpdateDiscussionModel updateModel);
    Task<bool> Delete(ulong id);
}