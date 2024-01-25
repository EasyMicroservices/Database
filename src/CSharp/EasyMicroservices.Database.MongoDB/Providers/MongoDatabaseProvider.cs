﻿using EasyMicroservices.Database.Interfaces;
using EasyMicroservices.Database.MongoDB.Implementations;
using EasyMicroservices.Database.Providers;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.MongoDB.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class MongoDatabaseProvider : IDatabase
    {
        private readonly IMongoDatabase _mongoDatabase;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mongoDatabase"></param>
        public MongoDatabaseProvider(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IEasyQueryableAsync<TEntity> GetQueryOf<TEntity>() where TEntity : class
        {
            return new QueryableProvider<TEntity>(new DatabaseContext(_mongoDatabase), GetReadableOf<TEntity>(), GetWritableOf<TEntity>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEasyReadableQueryableAsync<TEntity> GetReadableOf<TEntity>() where TEntity : class
        {
            return new MongoReadableQueryableProvider<TEntity>(new DatabaseContext(_mongoDatabase), _mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name).AsQueryable());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEasyWritableQueryableAsync<TEntity> GetWritableOf<TEntity>() where TEntity : class
        {
            return new MongoWritableQueryableProvider<TEntity>(new DatabaseContext(_mongoDatabase), _mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            return new ValueTask();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
        }
    }
}
