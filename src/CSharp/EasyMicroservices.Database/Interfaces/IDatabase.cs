using System;

namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabase : IDisposable
#if (!NET45 && !NETSTANDARD2_0)
        ,IAsyncDisposable
#endif
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IEasyQueryableAsync<TEntity> GetQueryOf<TEntity>()
            where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IEasyReadableQueryableAsync<TEntity> GetReadableOf<TEntity>()
            where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IEasyWritableQueryableAsync<TEntity> GetWritableOf<TEntity>()
            where TEntity : class;
    }
}
