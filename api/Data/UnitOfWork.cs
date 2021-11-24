using System;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Context;
using Sociussion.Data.Interfaces;
using Sociussion.Data.Models.Community;
using Sociussion.Data.Repositories;

namespace Sociussion.Data
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;

        private IGenericRepository<Community, string> community { get; set; }

        public IGenericRepository<Community, string> CommunityRepository
        {
            get
            {
                return community ??= new GenericRepository<Community, string>(_context);
            }
        }

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
