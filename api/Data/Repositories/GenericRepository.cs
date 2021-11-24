using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Interfaces;

namespace Sociussion.Data.Repositories
{
    public class GenericRepository<TEntity, TEntityId> : IGenericRepository<TEntity, TEntityId>, IDisposable
        where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> Get(TEntityId id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);

            if (result is not null && await _context.SaveChangesAsync() > 0)
            {
                return entity;
            }

            throw new Exception("Entity couldn't be added.");
        }

        public async void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        private bool Disposed { get; set; } = false;

        public void Dispose()
        {
            if (!Disposed)
            {
                _context.Dispose();
                Disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
