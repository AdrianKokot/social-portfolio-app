using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Communities;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Services;

public interface ICommunityService
{
    Task<Community> Get(int id);
    IQueryable<Community> GetAll();
    IQueryable<Community> GetAll(CommunityQueryParams queryParams);
    
    Task<Community> CreateFrom(CreateCommunityModel model, int createdBy);

    Task<bool> AddMember(int communityId, int userId);
    Task<bool> RemoveMember(int communityId, int userId);
    Task<CommunityViewModel> CreateFromAndGetVm(CreateCommunityModel createModel, int userId);
    
    Task<Community> Update(int entityId, UpdateCommunityModel updateModel);

    Task<CommunityViewModel> GetVm(int id);

    IQueryable<CommunityViewModel> GetAllVm(CommunityQueryParams queryParams);
    Task<bool> Delete(int id);
}