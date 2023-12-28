using EasyMicroservices.Database.DataTypes;
using EasyMicroservices.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.EntityFrameworkCore.Providers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityEntryProvider<TEntity> : IEntityEntry<TEntity>
        where TEntity : class
    {

        EntityEntry<TEntity> _entityEntry;
        TEntity _entity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityEntry"></param>
        public EntityEntryProvider(EntityEntry<TEntity> entityEntry)
        {
            _entityEntry = entityEntry;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public EntityEntryProvider(TEntity entity)
        {
            _entity = entity;
        }
        /// <summary>
        /// 
        /// </summary>
        public TEntity Entity
        {
            get
            {
                return _entity ?? _entityEntry.Entity;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public EntityStateType EntityState
        {
            get
            {
                return (EntityStateType)(_entityEntry?.State).GetValueOrDefault();
            }
            set
            {
                if (_entityEntry != null)
                    _entityEntry.State = (EntityState)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public IEntityEntry<TEntity> GetEntityEntryReference<TProperty>(Expression<Func<TEntity, IEnumerable<TProperty>>> func)
            where TProperty : class
        {
            return new EntityEntryProvider<TEntity>(_entityEntry.Reference(func).EntityEntry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEntityEntry GetEntityEntryReference(string propertyName)
        {
            return new EntityEntryProvider(_entityEntry.Reference(propertyName).EntityEntry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task ReloadAsync()
        {
            return _entityEntry.ReloadAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Task ReloadReferenceAsync(string propertyName)
        {
            return _entityEntry.Reference(propertyName).LoadAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Task ReloadCollectionAsync(string propertyName)
        {
            return _entityEntry.Collection(propertyName).LoadAsync();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EntityEntryProvider : IEntityEntry
    {

        EntityEntry _entityEntry;
        object _entity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityEntry"></param>
        public EntityEntryProvider(EntityEntry entityEntry)
        {
            _entityEntry = entityEntry;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public EntityEntryProvider(object entity)
        {
            _entity = entity;
        }
        /// <summary>
        /// 
        /// </summary>
        public object Entity
        {
            get
            {
                return _entity ?? _entityEntry.Entity;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public EntityStateType EntityState
        {
            get
            {
                return (EntityStateType)(_entityEntry?.State).GetValueOrDefault();
            }
            set
            {
                if (_entityEntry != null)
                    _entityEntry.State = (EntityState)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task ReloadAsync()
        {
            return _entityEntry.ReloadAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Task ReloadReferenceAsync(string propertyName)
        {
            return _entityEntry.Reference(propertyName).LoadAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Task ReloadCollectionAsync(string propertyName)
        {
            return _entityEntry.Collection(propertyName).LoadAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEntityEntry GetEntityEntryReference(string propertyName)
        {
            return new EntityEntryProvider(_entityEntry.Reference(propertyName).EntityEntry);
        }
    }
}
