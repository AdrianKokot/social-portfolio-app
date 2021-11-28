using System;
using Sociussion.Data.Context;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Community;
using Sociussion.Data.QueryParams;
using Sociussion.Data.Repositories;

namespace Sociussion.Data
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        private CommunityRepository Community { get; set; }

        public ICommunityRepository CommunityRepository
        {
            get
            {
                return Community ??= new CommunityRepository(_context);
            }
        }
        //
        // private IRepository<Discussion, ulong> discussion { get; set; }
        //
        // public IRepository<Discussion, ulong> DiscussionRepository
        // {
        //     get
        //     {
        //         return null;
        //         // return discussion ??= new GenericRepository<Discussion, ulong>(_context);
        //     }
        // }

        private bool Disposed { get; set; } = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                _context.Dispose();
            }

            Disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
