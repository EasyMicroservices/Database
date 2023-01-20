namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEasyQueryableAsync<TEntity> : IEasyWritableQueryableAsync<TEntity>, IEasyReadableQueryableAsync<TEntity>
        where TEntity : class
    {

    }
}
