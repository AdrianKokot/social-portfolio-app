using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Common.Exceptions;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Communities;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;
using Sociussion.Infrastructure.Persistence;

namespace Sociussion.Infrastructure.Services;

public class CommunityService : ICommunityService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly DbSet<Community> _set;

    public CommunityService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _context = dbContext;
        _mapper = mapper;
        _set = dbContext.Set<Community>();
    }

    public IQueryable<Community> Get(ulong id)
    {
        return _set.Where(x => x.Id == id);
    }

    public IQueryable<Community> GetAll()
    {
        return _set;
    }    
    
    public IQueryable<Community> GetAll(CommunityQueryParams queryParams)
    {
        var set = GetAll();
        
        if (queryParams.Member is not null)
        {
            set = set.Where(x => x.Members.Any(y => y.Id == queryParams.Member));
        }

        return set;
    }

    public async Task<Community> CreateFrom(CreateCommunityModel model, ulong createdBy)
    {
        var entity = new Community()
        {
            Description = model.Description,
            Name = model.Name,
            OwnerId = createdBy
        };

        var entry = _set.Add(entity);

        if (await _context.SaveChangesAsync() > 0)
        {
            return entry.Entity;
        }

        throw new Exception("Couldn't create given entity.");
    }

    public async Task<bool> AddMember(ulong communityId, ulong userId)
    {
        var community = await _set
            .Include(x => x.Members)
            .FirstOrDefaultAsync(x => x.Id == communityId);

        if (community is null)
        {
            throw new NotFoundException(nameof(Community), communityId);
        }

        var user = await _context.Set<ApplicationUser>().FindAsync(userId);

        if (user is null)
        {
            throw new NotFoundException(nameof(ApplicationUser), userId);
        }

        if (community.Members.Contains(user))
        {
            throw new Exception("User is already a member.");
        }

        community.Members.Add(user);
        community.MemberCount++;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveMember(ulong communityId, ulong userId)
    {
        var community = await _set
            .Include(x => x.Members)
            .FirstOrDefaultAsync(x => x.Id == communityId);

        if (community is null)
        {
            throw new NotFoundException(nameof(Community), communityId);
        }

        var user = await _context.Set<ApplicationUser>().FindAsync(userId);

        if (user is null)
        {
            throw new NotFoundException(nameof(ApplicationUser), userId);
        }
            
        if (!community.Members.Contains(user))
        {
            throw new Exception("User is not a member.");
        }

        if (community.Members.Remove(user))
        {
            community.MemberCount--;
        }

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<CommunityViewModel> CreateFromAndGetVm(CreateCommunityModel createModel, ulong userId)
    {
        var entity = await CreateFrom(createModel, userId);
        return await GetVm(entity.Id);
    }

    public async Task<Community> Update(ulong id, UpdateCommunityModel updateModel)
    {
        var entity = await Get(id).FirstOrDefaultAsync();

        if (entity is null)
        {
            throw new NotFoundException(nameof(Community), id);
        }

        entity.Description = updateModel.Description;
        entity.Name = updateModel.Name;
        
        if (await _context.SaveChangesAsync() > 0)
        {
            return entity;
        }
        
        throw new Exception("Couldn't update given entity.");
    }

    public async Task<CommunityViewModel> GetVm(ulong id)
    {
        var query = Get(id);
        var entity = await _mapper.ProjectTo<CommunityViewModel>(query).FirstOrDefaultAsync();

        if (entity is null)
        {
            throw new NotFoundException(nameof(Community), id);
        }

        return entity;
    }

    public IQueryable<CommunityViewModel> GetAllVm(CommunityQueryParams queryParams)
    {
        var query = GetAll(queryParams);

        return _mapper.ProjectTo<CommunityViewModel>(query);
    }

    public async Task<bool> Delete(ulong id)
    {
        var entity = await Get(id).FirstOrDefaultAsync();

        if (entity is null)
        {
            throw new NotFoundException(nameof(Community), id);
        }

        _set.Remove(entity);

        return await _context.SaveChangesAsync() > 0;
    }
}