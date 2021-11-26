using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Collections;
using Sociussion.Data.Context;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Community;

namespace Sociussion.Data.Repositories
{
    public class CommunityRepository : Repository<Community, ulong>
    {
        public CommunityRepository(DbContext context)
            : base(context)
        {
        }
    }
}
