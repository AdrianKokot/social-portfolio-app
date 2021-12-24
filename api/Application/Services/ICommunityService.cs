using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Communities;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Services;

public interface ICommunityService
{
    IQueryable<Community> Get(ulong id);
    IQueryable<Community> GetAll();
    IQueryable<Community> GetAll(CommunityQueryParams queryParams);
    
    Task<Community> CreateFrom(CreateCommunityModel model, ulong createdBy);

    Task<bool> AddMember(ulong communityId, ulong userId);
    Task<bool> RemoveMember(ulong communityId, ulong userId);
    Task<CommunityViewModel> CreateFromAndGetVm(CreateCommunityModel createModel, ulong userId);
    
    Task<Community> Update(ulong entityId, UpdateCommunityModel updateModel);

    Task<CommunityViewModel> GetVm(ulong id);

    IQueryable<CommunityViewModel> GetAllVm(CommunityQueryParams queryParams);
    Task<bool> Delete(ulong id);
}