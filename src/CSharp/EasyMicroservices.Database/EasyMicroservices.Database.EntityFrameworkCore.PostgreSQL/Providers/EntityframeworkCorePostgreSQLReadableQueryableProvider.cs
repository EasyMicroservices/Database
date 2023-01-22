using EasyMicroservices.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.EntityFrameworkCore.PostgreSQL.Providers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityframeworkCorePostgreSQLReadableQueryableProvider<TEntity> : IEasyReadableQueryableAsync<TEntity>
        where TEntity : class
    {
        private readonly IQueryable<TEntity> _queryable;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryable"></param>
        public EntityframeworkCorePostgreSQLReadableQueryableProvider(IQueryable<TEntity> queryable)
        {
            _queryable = queryable;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type ElementType => _queryable.ElementType;
        /// <summary>
        /// 
        /// </summary>
        public Expression Expression => _queryable.Expression;
        /// <summary>
        /// 
        /// </summary>
        public IQueryProvider Provider => _queryable.Provider;

        #region QueryMethods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.AllAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.AnyAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.AnyAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IAsyncEnumerable<TEntity> AsAsyncEnumerable()
        {
            return _queryable.AsAsyncEnumerable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<decimal> AverageAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<decimal?> AverageAsync(Expression<Func<TEntity, decimal?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double> AverageAsync(Expression<Func<TEntity, int>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double?> AverageAsync(Expression<Func<TEntity, int?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double> AverageAsync(Expression<Func<TEntity, long>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double?> AverageAsync(Expression<Func<TEntity, long?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double> AverageAsync(Expression<Func<TEntity, double>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double?> AverageAsync(Expression<Func<TEntity, double?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<float> AverageAsync(Expression<Func<TEntity, float>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<float?> AverageAsync(Expression<Func<TEntity, float?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.AverageAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> ContainsAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            return _queryable.ContainsAsync(item, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.CountAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.CountAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> FirstAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.FirstAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.FirstAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.FirstOrDefaultAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> LastAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.LastAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> LastAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.LastAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> LastOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.LastOrDefaultAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.LastOrDefaultAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.LoadAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<long> LongCountAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.LongCountAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.LongCountAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> MaxAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.MaxAsync(cancellationToken);
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
            return _queryable.MaxAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> MinAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.MinAsync(cancellationToken);
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
            return _queryable.MinAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> SingleAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.SingleAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.SingleAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.SingleOrDefaultAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _queryable.SingleOrDefaultAsync(predicate, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<decimal?> SumAsync(Expression<Func<TEntity, decimal?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SumAsync(Expression<Func<TEntity, int>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int?> SumAsync(Expression<Func<TEntity, int?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<long> SumAsync(Expression<Func<TEntity, long>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<long?> SumAsync(Expression<Func<TEntity, long?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double> SumAsync(Expression<Func<TEntity, double>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<double?> SumAsync(Expression<Func<TEntity, double?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<float> SumAsync(Expression<Func<TEntity, float>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<float?> SumAsync(Expression<Func<TEntity, float?>> selector, CancellationToken cancellationToken = default)
        {
            return _queryable.SumAsync(selector, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TEntity[]> ToArrayAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.ToArrayAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return _queryable.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            return _queryable.ToQueryString();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TEntity> GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }
    }
}
