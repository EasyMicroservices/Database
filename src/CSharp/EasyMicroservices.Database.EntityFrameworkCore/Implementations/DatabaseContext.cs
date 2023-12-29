using EasyMicroservices.Database.DataTypes;
using EasyMicroservices.Database.EntityFrameworkCore.Providers;
using EasyMicroservices.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.EntityFrameworkCore.Implementations
{
    internal class DatabaseContext : IContext
    {
        public DatabaseContext(DbContext dbContext)
        {
            _dbContext = dbContext;
            ContextType = _dbContext.GetType();
        }

        DbContext _dbContext;
        public Type ContextType { get; set; }

        public string GetContextName()
        {
            return ContextType.Name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <param name="isModified"></param>
        public void ChangeModificationPropertyState<T>(T entity, string property, bool isModified)
            where T : class
        {
            _dbContext.Entry(entity).Property(property).IsModified = isModified;
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
            _dbContext.Entry(entity).State = (EntityState)entityStateType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public IEntityEntry Entry<T>(T entity)
            where T : class
        {
            return new EntityEntryProvider(_dbContext.Entry(entity));
        }

        public IEnumerable<IPropertyEntry> GetProperties<T>(T entity) where T : class
        {
            return _dbContext.Entry(entity).Properties.Select(x => new PropertyEntry(x));
        }

        public IEnumerable<IPropertyEntry> GetProperties(object entity)
        {
            return _dbContext.Entry(entity).Properties.Select(x => new PropertyEntry(x));
        }

        public IEnumerable<IEntityEntry> GetTrackerEntities()
        {
            return _dbContext.ChangeTracker.Entries().Select(x => new EntityEntryProvider(x));
        }

        public Task Reload<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            return _dbContext.Entry(entity).ReloadAsync(cancellationToken);
        }

        public object[] GetPrimaryKeyValues<TEntity>(TEntity entity)
        {
            var entityType = _dbContext.Model.FindEntityType(typeof(TEntity));
            var primaryKey = entityType.FindPrimaryKey();

            return primaryKey.Properties.Select(
                pkProperty => entityType.FindProperty(pkProperty.Name).GetGetter().GetClrValue(entity))
                .ToArray();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }
    }
}
