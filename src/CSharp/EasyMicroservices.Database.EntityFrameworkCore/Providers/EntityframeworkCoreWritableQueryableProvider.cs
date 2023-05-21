using EasyMicroservices.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace EasyMicroservices.Database.EntityFrameworkCore.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityFrameworkCoreWritableQueryableProvider<TEntity> : IEasyWritableQueryableAsync<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EntityFrameworkCoreWritableQueryableProvider(DbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            return new EntityEntryProvider<TEntity>(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEntityEntry<TEntity>> RemoveAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var removeItems = await _context.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
            _context.Set<TEntity>().RemoveRange(removeItems);
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEntityEntry<TEntity>> RemoveAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var removeItem = await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync(cancellationToken);
            var result = _context.Set<TEntity>().Remove(removeItem);
            return new EntityEntryProvider<TEntity>(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
