namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IEasyQueryableAsync<TEntity> GetQueryOf<TEntity>()
            where TEntity : class;
    }
}
