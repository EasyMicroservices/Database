using EasyMicroservices.Database.Interfaces;
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
    }
}
