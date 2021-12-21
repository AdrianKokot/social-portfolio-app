using Sociussion.Application.Communities;
using Sociussion.Domain.Entities;

namespace Sociussion.Application.Services;

public interface ICommunityService
{
    IQueryable<Community> Get(ulong id);
    IQueryable<Community> GetAll();

    Task<Community> CreateFrom(CreateCommunityModel model, ulong createdBy);
    // Task<Community> Add(Community entity);
    // void Delete(Community entity);
    // void Update(Community entity);
    Task<bool> AddMember(ulong communityId, ulong userId);
    Task<bool> RemoveMember(ulong communityId, ulong userId);
}