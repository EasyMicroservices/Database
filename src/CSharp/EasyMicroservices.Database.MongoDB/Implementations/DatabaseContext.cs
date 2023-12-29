using EasyMicroservices.Database.DataTypes;
using EasyMicroservices.Database.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.MongoDB.Implementations
{
    internal class DatabaseContext : IContext
    {
        public DatabaseContext(IMongoDatabase dbContext)
        {
            _dbContext = dbContext;
            ContextType = _dbContext.GetType();
        }

        IMongoDatabase _dbContext;
        public Type ContextType { get; set; }

        public string GetContextName()
        {
            return _dbContext.DatabaseNamespace.DatabaseName;
        }

        public void ChangeModificationPropertyState<T>(T entity, string property, bool isModified) where T : class
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="entityStateType"></param>
        public void ChangeEntityState<T>(T entity, EntityStateType entityStateType)
            where T : class
        {
        }

        public IEnumerable<IPropertyEntry> GetProperties<T>(T entity) where T : class
        {
            return Enumerable.Empty<IPropertyEntry>();
        }

        public IEnumerable<IPropertyEntry> GetProperties(object entity)
        {
            return Enumerable.Empty<IPropertyEntry>();
        }

        public IEnumerable<IEntityEntry> GetTrackerEntities()
        {
            return Enumerable.Empty<IEntityEntry>();
        }

        public Task Reload<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            return Task.CompletedTask;
        }

        public IEntityEntry Entry<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void Dispose()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }

        public object[] GetPrimaryKeyValues<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
