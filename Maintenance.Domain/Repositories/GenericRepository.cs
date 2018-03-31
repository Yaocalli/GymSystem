using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Yaocalli.GymSystem.Shared.DataAcces;

namespace Maintenance.Domain.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, IEntity
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }


        public async Task<TEntity> FindBykey(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(e => e.Id == id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async void SaveAsync(TEntity entity)
        {
           await _dbSet.SingleAsync();
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
            IQueryable<TEntity> queryable = _dbSet.AsNoTracking();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
