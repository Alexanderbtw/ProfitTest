using Microsoft.EntityFrameworkCore;
using ProfitTest.Core.Interfaces.DAL;
using System.Linq.Expressions;

namespace OrderDelivery.DAL.Repositories
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default)
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync(token)
                .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default)
        {
            return await _dbSet
                .Where(expression)
                .ToListAsync(token)
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity?> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _dbSet.FindAsync([id], cancellationToken: token).ConfigureAwait(false);
        }

        public virtual async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default)
        {
            return await _dbSet
                .FirstOrDefaultAsync(expression, token)
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default)
        {
            var res = await _dbSet.AddAsync(entity, token).ConfigureAwait(false);

            return res.Entity;
        }

        public virtual async Task<bool> RemoveAsync(Guid id, CancellationToken token = default)
        {
            var res = await _dbSet.FindAsync([id], cancellationToken: token).ConfigureAwait(false);

            if (res == null) { return false; }
            _dbSet.Remove(res);
            return true;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var res = _dbSet.Update(entity);

            return res.Entity;
        }
    }
}
