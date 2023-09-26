using EasyMicroservices.Database.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryableProvider<TEntity> : IEasyQueryableAsync<TEntity>
        where TEntity : class
    {
        private readonly IEasyReadableQueryableAsync<TEntity> _readable;
        private readonly IEasyWritableQueryableAsync<TEntity> _writable;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="readable"></param>
        /// <param name="writable"></param>
        public QueryableProvider(IContext context, IEasyReadableQueryableAsync<TEntity> readable, IEasyWritableQueryableAsync<TEntity> writable)
        {
            _readable = readable;
            _writable = writable;
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public Type ElementType => _readable.ElementType;
        /// <summary>
        /// 
        /// </summary>
        public Expression Expression => _readable.Expression;
        /// <summary>
        /// 
        /// </summary>
        public IQueryProvider Provider => _readable.Provider;
        /// <summary>
        /// 
        /// </summary>
        public IContext Context { get; set; }

        #region Writable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return _writable.AddAsync(entity, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<IEntityEntry<TEntity>>> AddBulkAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return _writable.AddBulkAsync(entities, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEntityEntry<TEntity>> RemoveAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _writable.RemoveAsync(predicate, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEntityEntry<TEntity>> RemoveAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _writable.RemoveAllAsync(predicate, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _writable.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEntityEntry<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var updateResult = await _writable.UpdateAsync(entity, cancellationToken);
            await _writable.SaveChangesAsync();
            return updateResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IEntityEntry<TEntity>>> UpdateBulkAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            var updateResult = await _writable.UpdateBulkAsync(entities, cancellationToken);
            await _writable.SaveChangesAsync();
            return updateResult;
        }

        #endregion

        #region Readable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.AllAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return _readable.AnyAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.AnyAsync(predicate, cancellationToken);
        }
#if (!NETSTANDARD2_0 && !NET45)
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IAsyncEnumerable<TEntity> AsAsyncEnumerable()
        {
            return _readable.AsAsyncEnumerable();
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<decimal> AverageAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<decimal?> AverageAsync(Expression<Func<TEntity, decimal?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double> AverageAsync(Expression<Func<TEntity, int>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double?> AverageAsync(Expression<Func<TEntity, int?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double> AverageAsync(Expression<Func<TEntity, long>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double?> AverageAsync(Expression<Func<TEntity, long?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double> AverageAsync(Expression<Func<TEntity, double>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double?> AverageAsync(Expression<Func<TEntity, double?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<float> AverageAsync(Expression<Func<TEntity, float>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<float?> AverageAsync(Expression<Func<TEntity, float?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> ContainsAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            return _readable.ContainsAsync(item, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return _readable.CountAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.CountAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> FirstAsync(CancellationToken cancellationToken = default)
        {
            return _readable.FirstAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.FirstAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return _readable.FirstOrDefaultAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.FirstOrDefaultAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerator<TEntity> GetEnumerator()
        {
            return _readable.GetEnumerator();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> LastAsync(CancellationToken cancellationToken = default)
        {
            return _readable.LastAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> LastAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.LastAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> LastOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return _readable.LastAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.LastOrDefaultAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            return _readable.LoadAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<long> LongCountAsync(CancellationToken cancellationToken = default)
        {
            return _readable.LongCountAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.LongCountAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> MaxAsync(CancellationToken cancellationToken = default)
        {
            return _readable.MaxAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TResult> MaxAsync<TResult>(Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.MaxAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<TEntity> MinAsync(CancellationToken cancellationToken = default)
        {
            return _readable.MinAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TResult> MinAsync<TResult>(Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.MinAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> SingleAsync(CancellationToken cancellationToken = default)
        {
            return _readable.SingleAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.SingleAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return _readable.SingleOrDefaultAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _readable.SingleOrDefaultAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<decimal?> SumAsync(Expression<Func<TEntity, decimal?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SumAsync(Expression<Func<TEntity, int>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int?> SumAsync(Expression<Func<TEntity, int?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<long> SumAsync(Expression<Func<TEntity, long>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<long?> SumAsync(Expression<Func<TEntity, long?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double> SumAsync(Expression<Func<TEntity, double>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double?> SumAsync(Expression<Func<TEntity, double?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<float> SumAsync(Expression<Func<TEntity, float>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<float?> SumAsync(Expression<Func<TEntity, float?>> selector, CancellationToken cancellationToken = default)
        {
            return _readable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity[]> ToArrayAsync(CancellationToken cancellationToken = default)
        {
            return _readable.ToArrayAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return _readable.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            return _readable.ToQueryString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _readable.GetEnumerator();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEasyReadableQueryableAsync<TEntity> ConvertToReadable(IQueryable<TEntity> query)
        {
            return _readable.ConvertToReadable(query);
        }

        #endregion
    }
}
