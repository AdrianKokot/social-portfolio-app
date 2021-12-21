using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Communities;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;
using Sociussion.Infrastructure.Persistence;

namespace Sociussion.Infrastructure.Services;

public class CommunityService : ICommunityService
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Community> _set;

    public CommunityService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
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
            throw new Exception("Community doesn't exist.");
        }

        var user = await _context.Set<ApplicationUser>().FindAsync(userId);

        if (user is null)
        {
            throw new Exception("User doesn't exist.");
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
            throw new Exception("Community doesn't exist.");
        }

        var user = await _context.Set<ApplicationUser>().FindAsync(userId);

        if (user is null)
        {
            throw new Exception("User doesn't exist.");
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
}