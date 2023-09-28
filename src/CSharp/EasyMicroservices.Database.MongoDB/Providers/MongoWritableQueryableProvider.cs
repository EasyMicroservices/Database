using EasyMicroservices.Database.Interfaces;
using EasyMicroservices.Database.MongoDB.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEntityEntry<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IEntityEntry<TEntity>>> AddBulkAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _mongoCollection.InsertManyAsync(entities);
            return entities.Select(x => new DocumentEntryProvider<TEntity>(x));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IEntityEntry<TEntity>>> UpdateBulkAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            var updates = new List<WriteModel<TEntity>>();
            var filterBuilder = Builders<TEntity>.Filter;

            foreach (var doc in entities)
            {
                if (doc is IMongoDocument document)
                {
                    var filter = filterBuilder.Where(x => ((IMongoDocument)x).Id == document.Id);
                    updates.Add(new ReplaceOneModel<TEntity>(filter, doc));
                }
            }

            var result = await _mongoCollection.BulkWriteAsync(updates);
            return entities.Select(x => new DocumentEntryProvider<TEntity>(x));
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
