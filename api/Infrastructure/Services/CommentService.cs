using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Comments;
using Sociussion.Application.Common.Exceptions;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;
using Sociussion.Infrastructure.Persistence;

namespace Sociussion.Infrastructure.Services;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly DbSet<Comment> _set;

    public CommentService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _context = dbContext;
        _mapper = mapper;
        _set = dbContext.Set<Comment>();
    }

    public IQueryable<Comment> Get(ulong id)
    {
        return _set.Where(x => x.Id == id);
    }

    public IQueryable<Comment> GetAll()
    {
        return _set.AsQueryable().OrderByDescending(x => x.CreatedAt);
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
            throw new NotFoundException(nameof(Discussion), createModel.DiscussionId);
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

    public async Task<CommentViewModel> CreateFromAndGetVm(CreateCommentModel createModel, ulong userId)
    {
        var entity = await CreateFrom(createModel, userId);
        return await GetVm(entity.Id);
    }

    public async Task<Comment> Update(ulong id, UpdateCommentModel updateModel)
    {
        var entity = await _set.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (entity is null)
        {
            throw new NotFoundException(nameof(Comment), id);
        }

        entity.Content = updateModel.Content;
        
        if (await _context.SaveChangesAsync() > 0)
        {
            return entity;
        }
        
        throw new Exception("Couldn't update given entity.");
    }

    public async Task<CommentViewModel> GetVm(ulong id)
    {
        var entity = await _mapper.ProjectTo<CommentViewModel>(Get(id)).FirstOrDefaultAsync();

        if (entity is null)
        {
            throw new NotFoundException(nameof(Community), id);
        }

        return entity;
    }

    public IQueryable<CommentViewModel> GetAllVm(CommentQueryParams queryParams)
    {
        return _mapper.ProjectTo<CommentViewModel>(GetAll(queryParams));
    }

    public async Task<bool> Delete(ulong id)
    {
        var entity = await Get(id).FirstOrDefaultAsync();

        if (entity is null)
        {
            throw new NotFoundException(nameof(Comment), id);
        }

        _set.Remove(entity);

        return await _context.SaveChangesAsync() > 0;
    }
}