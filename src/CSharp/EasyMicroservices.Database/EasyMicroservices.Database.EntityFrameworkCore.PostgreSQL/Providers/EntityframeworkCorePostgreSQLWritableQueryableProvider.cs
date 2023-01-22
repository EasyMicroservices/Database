using EasyMicroservices.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.EntityFrameworkCore.PostgreSQL.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityframeworkCorePostgreSQLWritableQueryableProvider<TEntity> : IEasyWritableQueryableAsync<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dbSet"></param>
        public EntityframeworkCorePostgreSQLWritableQueryableProvider(DbContext context, DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
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
            var result = await _dbSet.AddAsync(entity, cancellationToken);
            return new EntityEntryProvider<TEntity>(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
