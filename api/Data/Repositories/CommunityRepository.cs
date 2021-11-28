using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Collections;
using Sociussion.Data.Context;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models;
using Sociussion.Data.Models.Community;
using Sociussion.Data.QueryParams;

namespace Sociussion.Data.Repositories
{
    public class CommunityRepository : Repository<Community, ulong, CommunityParams>
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
    }
}
