using EasyMicroservices.Database.DataTypes;
using EasyMicroservices.Database.Interfaces;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.MongoDB.Providers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DocumentEntryProvider<TEntity> : IEntityEntry<TEntity>
        where TEntity : class
    {

        TEntity _entity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public DocumentEntryProvider(TEntity entity)
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
                return _entity;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public EntityStateType EntityState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEntityEntry<TEntity> GetEntityEntryReference<TProperty>(System.Linq.Expressions.Expression<System.Func<TEntity, System.Collections.Generic.IEnumerable<TProperty>>> func) where TProperty : class
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEntityEntry GetEntityEntryReference(string propertyName)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task ReloadAsync()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task ReloadCollectionAsync(string propertyName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task ReloadReferenceAsync(string propertyName)
        {
            throw new System.NotImplementedException();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DocumentEntryProvider : IEntityEntry
    {
        object _entity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public DocumentEntryProvider(object entity)
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
                return _entity;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public EntityStateType EntityState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEntityEntry GetEntityEntryReference(string propertyName)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task ReloadAsync()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task ReloadCollectionAsync(string propertyName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task ReloadReferenceAsync(string propertyName)
        {
            throw new System.NotImplementedException();
        }
    }
}