using EasyMicroservices.Database.DataTypes;
using EasyMicroservices.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
    }
}
