using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Common.Exceptions;
using Sociussion.Application.Common.QueryParams;
using Sociussion.Application.Discussions;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;
using Sociussion.Infrastructure.Persistence;

namespace Sociussion.Infrastructure.Services;

public class DiscussionService : IDiscussionService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly DbSet<Discussion> _set;

    public DiscussionService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _context = dbContext;
        _mapper = mapper;
        _set = dbContext.Set<Discussion>();
    }

    public async Task<Discussion> Get(int id)
    {
        var entity = await _set.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (entity is null)
        {
            throw new NotFoundException(nameof(Discussion), id);
        }

        return entity;
    }

    public IQueryable<Discussion> GetAll()
    {
        return _set.AsQueryable();
    }

    public IQueryable<Discussion> GetAll(DiscussionQueryParams queryParams)
    {
        var set = GetAll();

        if (queryParams.CommunityId is not null)
        {
            set = set.Where(x => x.CommunityId == queryParams.CommunityId);
        }

        return set;
    }

    public async Task<Discussion> CreateFrom(CreateDiscussionModel createModel, int getUserId)
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
            return entry.Entity;
        }

        throw new Exception("Couldn't create given entity.");
    }

    public async Task<DiscussionViewModel> CreateFromAndGetVm(CreateDiscussionModel createModel, int userId)
    {
        var entity = await CreateFrom(createModel, userId);
        return await GetVm(entity.Id);
    }

    public IQueryable<DiscussionViewModel> GetAllVm(DiscussionQueryParams queryParams)
    {
        return _mapper.ProjectTo<DiscussionViewModel>(GetAll(queryParams));
    }

    public async Task<DiscussionViewModel> GetVm(int id)
    {
        var entity = await _mapper.ProjectTo<DiscussionViewModel>(_set).FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Discussion), id);
        }

        return entity;
    }

    public async Task<Discussion> Update(int id, UpdateDiscussionModel updateModel)
    {
        var entity = await Get(id);
        
        entity.Content = updateModel.Content;
        
        if (await _context.SaveChangesAsync() > 0)
        {
            return entity;
        }
        
        throw new Exception("Couldn't update given entity.");
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await Get(id);

        _set.Remove(entity);

        return await _context.SaveChangesAsync() > 0;
    }
}