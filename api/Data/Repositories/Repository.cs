using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Collections;
using Sociussion.Data.Interfaces;

namespace Sociussion.Data.Repositories
{
    public abstract class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId>, IDisposable
        where TEntity : class
    {
        internal readonly DbContext Context;
        internal readonly DbSet<TEntity> Set;

        protected Repository(DbContext context)
        {
            Context = context;
            Set = Context.Set<TEntity>();
        }

        public virtual async Task<TEntity> Get(TEntityId id)
        {
            return await Set.FindAsync(id);
        }

        public virtual async Task<PaginatedList<TEntity>> GetAll(PaginationParams paginationParams)
        {
            return await PaginatedList<TEntity>.FromQueryableAsync(Set.AsQueryable(), paginationParams);
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            var result = await Set.AddAsync(entity);

            if (result is not null && await Context.SaveChangesAsync() > 0)
            {
                return entity;
            }

            throw new Exception("Entity couldn't be added.");
        }

        public virtual async void Delete(TEntity entity)
        {
            Set.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async void Update(TEntity entity)
        {
            Set.Update(entity);
            await Context.SaveChangesAsync();
        }

        private bool Disposed { get; set; } = false;

        public virtual void Dispose()
        {
            if (!Disposed)
            {
                Context.Dispose();
                Disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
