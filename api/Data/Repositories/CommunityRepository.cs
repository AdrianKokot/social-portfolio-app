using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Collections;
using Sociussion.Data.Context;
using Sociussion.Data.Models.Community;
using Sociussion.Data.QueryParams;

namespace Sociussion.Data.Repositories
{
    public class CommunityRepository : Repository<Community, ulong, CommunityParams>, ICommunityRepository
    {
        private readonly ApplicationDbContext _context;

        public CommunityRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<PaginatedList<Community>> GetAll(CommunityParams queryParams)
        {
            var query = Set.AsQueryable();

            if (queryParams.Member is not null)
            {
                query = _context.Users
                    .Where(u => u.Id == queryParams.Member)
                    .SelectMany(u => u.MemberOfCommunities)
                    .Distinct();
            }

            return await PaginatedList<Community>.FromQueryableAsync(query.OrderBy(c => c.Name), queryParams);
        }

        public async Task<bool> AddMember(ulong communityId, string userId)
        {
            var community = await Set
                .Include(x => x.Members)
                .FirstOrDefaultAsync(x => x.Id == communityId);

            if (community is null)
            {
                throw new Exception("Community doesn't exist.");
            }

            var user = await _context.Users.FindAsync(userId);

            if (user is null)
            {
                throw new Exception("User doesn't exist.");
            }

            if (community.Members.Contains(user))
            {
                throw new Exception("User is already a member.");
            }

            community.Members.Add(user);
            community.MembersCount++;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveMember(ulong communityId, string userId)
        {
            var community = await Set
                .Include(x => x.Members)
                .FirstOrDefaultAsync(x => x.Id == communityId);

            if (community is null)
            {
                throw new Exception("Community doesn't exist.");
            }

            var user = await _context.Users.FindAsync(userId);

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
                community.MembersCount--;
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
