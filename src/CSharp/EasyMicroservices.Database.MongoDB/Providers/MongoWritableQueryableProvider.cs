using EasyMicroservices.Database.Interfaces;
using EasyMicroservices.Database.MongoDB.Interfaces;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
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
        public IContext Context { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mongoCollection"></param>
        public MongoWritableQueryableProvider(IContext context, IMongoCollection<TEntity> mongoCollection)
        {
            _mongoCollection = mongoCollection;
            Context = context;
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
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEntityEntry<TEntity>> Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity is IMongoDocument mongoDocument)
            {
                var filter = Builders<TEntity>.Filter.Eq("_id", mongoDocument.Id);
                await _mongoCollection.ReplaceOneAsync(filter, entity, (ReplaceOptions)null, cancellationToken);
                return new DocumentEntryProvider<TEntity>(entity);
            }
            else
                throw new Exception("I cannot update the document please inherit your document from IMongoDocument");
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
