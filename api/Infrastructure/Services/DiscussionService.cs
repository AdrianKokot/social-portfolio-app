using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Discussions;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;
using Sociussion.Infrastructure.Persistence;

namespace Sociussion.Infrastructure.Services;

public class DiscussionService : IDiscussionService
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Discussion> _set;

    public DiscussionService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
        _set = dbContext.Set<Discussion>();
    }

    public IQueryable<Discussion> Get(ulong id)
    {
        return _set.Where(x => x.Id == id);
    }

    public IQueryable<Discussion> GetAll()
    {
        return _set.AsQueryable();
    }
    
    public async Task<Discussion> CreateFrom(CreateDiscussionModel createModel, ulong getUserId)
    {
        var entity = new Discussion()
        {
            Title = createModel.Title,
            Content = createModel.Content,
            CommunityId = createModel.CommunityId,
            AuthorId = getUserId
        };

        var entry = _set.Add(entity);

        if (await _context.SaveChangesAsync() > 0)
        {
            var result = await _set.FirstOrDefaultAsync(x => x.Id == entry.Entity.Id);
            if (result is not null)
            {
                return result;
            }
        }

        throw new Exception("Couldn't create given entity.");
    }
}