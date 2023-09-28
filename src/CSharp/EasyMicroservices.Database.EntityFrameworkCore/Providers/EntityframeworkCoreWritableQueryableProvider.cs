using EasyMicroservices.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EasyMicroservices.Database.EntityFrameworkCore.Implementations;
using System.Collections.Generic;

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
        public IContext Context { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EntityFrameworkCoreWritableQueryableProvider(DbContext context)
        {
            _context = context;
            Context = new DatabaseContext(context);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEntityEntry<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var result = _context.Set<TEntity>().Update(entity);
            return Task.FromResult((IEntityEntry<TEntity>)new EntityEntryProvider<TEntity>(result));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IEntityEntry<TEntity>>> AddBulkAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            return entities.Select(x => (IEntityEntry<TEntity>)new EntityEntryProvider<TEntity>(x));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<IEntityEntry<TEntity>>> UpdateBulkAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            return Task.FromResult(entities.Select(x => (IEntityEntry<TEntity>)new EntityEntryProvider<TEntity>(x)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void Dispose()
        {
            Context.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ValueTask DisposeAsync()
        {
            return Context.DisposeAsync();
        }
    }
}
