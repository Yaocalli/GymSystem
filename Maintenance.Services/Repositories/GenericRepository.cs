using Maintenance.Domain.Contracts;
using Maintenance.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Maintenance.Services.Repositories
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext

    {

        protected readonly TContext Context;

        protected GenericRepository(TContext context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await Context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdOrDefaultAsync(int id)
        {
            return await Context.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public async void DeleteById(int id)
        {
            var entity = await GetByIdAsync(id);
            Context.Set<TEntity>().Remove(entity);
        }

        public async Task SaveAsync(TEntity entity)
        {
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> AllIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await GetAllIncluding(includeProperties).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindByIncludeAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await GetAllIncluding(includeProperties).Where(predicate).ToListAsync();
        }

        private IQueryable<TEntity> GetAllIncluding
            (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>().AsNoTracking();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}


