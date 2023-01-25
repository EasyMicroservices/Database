using EasyMicroservices.Database.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.MongoDB.Providers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MongoWritableQueryableProvider<TEntity> : IEasyWritableQueryableAsync<TEntity>
        where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _mongoCollection;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mongoCollection"></param>
        public MongoWritableQueryableProvider(IMongoCollection<TEntity> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _mongoCollection.InsertOneAsync(entity, null, cancellationToken);
            return new DocumentEntryProvider<TEntity>(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEntityEntry<TEntity>> RemoveAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(predicate, null, cancellationToken);
            return new DocumentEntryProvider<TEntity>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEntityEntry<TEntity>> RemoveAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var deleteResult = await _mongoCollection.DeleteManyAsync(predicate, null, cancellationToken);
            return new DocumentEntryProvider<TEntity>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(1);
        }
    }
}
