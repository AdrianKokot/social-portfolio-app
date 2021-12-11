using System.Linq;
using System.Threading.Tasks;
using Sociussion.Data.Collections;
using Sociussion.Data.Context;
using Sociussion.Data.Models.Comment;
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

            if (queryParams.CommunityId is not null)
            {
                query = query.Where(x => x.CommunityId == queryParams.CommunityId);
            }

            return await PaginatedList<Comment>.FromQueryableAsync(query.OrderBy(c => c.CreatedAt), queryParams);
        }
    }
}
