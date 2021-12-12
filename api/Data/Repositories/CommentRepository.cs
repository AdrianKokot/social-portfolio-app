using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Collections;
using Sociussion.Data.Context;
using Sociussion.Data.Models.Comment;
using Sociussion.Data.Models.Discussion;
using Sociussion.Data.QueryParams;

namespace Sociussion.Data.Repositories
{
    public class CommentRepository : Repository<Comment, ulong, CommentParams>, ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<PaginatedList<Comment>> GetAll(CommentParams queryParams)
        {
            var query = Set.AsQueryable();

            if (queryParams.DiscussionId is not null)
            {
                query = query.Where(x => x.DiscussionId == queryParams.DiscussionId)
                    .Include(c => c.Author);
            }

            // return await PaginatedList<Comment>.FromQueryableAsync(query.OrderBy(c => c.CreatedAt), queryParams);
            return await PaginatedList<Comment>.FromQueryableAsync(query, queryParams);
        }

        public override async Task<Comment> Add(Comment entity)
        {
            var result = await Set.AddAsync(entity);

            if (result is null || await Context.SaveChangesAsync() == 0)
            {
                throw new Exception("Entity couldn't be added.");
            }
            
            var discussion = await _context.Set<Discussion>()
                .Where(x => x.Id == entity.DiscussionId)
                .Include(x => x.Community)
                .FirstOrDefaultAsync();
            
            if (discussion is not null)
            {
                discussion.CommentsCount++;
                discussion.LastActive = DateTime.UtcNow;
                discussion.Community.LastActive = DateTime.UtcNow;
            }


            if (await Context.SaveChangesAsync() > 0)
            {
                return entity;
            }


            throw new Exception("Entity couldn't be added.");
        }
    }
}
