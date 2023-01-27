using EasyMicroservices.Database.Interfaces;

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
    }
}