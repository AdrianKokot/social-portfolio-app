using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Comments;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;
using Sociussion.Infrastructure.Persistence;

namespace Sociussion.Infrastructure.Services;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Comment> _set;

    public CommentService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
        _set = dbContext.Set<Comment>();
    }

    public IQueryable<Comment> Get(ulong id)
    {
        return _set.Where(x => x.Id == id);
    }

    public IQueryable<Comment> GetAll()
    {
        return _set.AsQueryable();
    }
    
    public IQueryable<Comment> GetAll(CommentQueryParams queryParams)
    {
        var set = GetAll();

        if (queryParams.DiscussionId is not null)
        {
            set = set.Where(x => x.DiscussionId == queryParams.DiscussionId);
        }
        
        return set;
    }

    public async Task<Comment> CreateFrom(CreateCommentModel createModel, ulong getUserId)
    {
        var discussion = await _context.Set<Discussion>().FirstOrDefaultAsync(x => x.Id == createModel.DiscussionId);
        
        if (discussion is null)
        {
            throw new Exception("Discussion doesn't exist.");
        }

        var entity = new Comment()
        {
            Content = createModel.Content,
            DiscussionId = createModel.DiscussionId,
            AuthorId = getUserId
        };

        var entry = _set.Add(entity);
        discussion.CommentCount++;

        if (await _context.SaveChangesAsync() > 0)
        {
            return entry.Entity;
        }

        throw new Exception("Couldn't create given entity.");
    }
}