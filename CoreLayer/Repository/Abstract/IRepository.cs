﻿using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        GetManyResult<TEntity> AsQueryable();
        Task<GetManyResult<TEntity>> ASQueryableAsync();
        GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);
        GetOneResult<TEntity> GetById(string id);
        Task<GetOneResult<TEntity>> GetByIdAsync(string id);
        GetOneResult<TEntity> InsertOne(TEntity entity);
        Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity);
        GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities);
        Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> entities);
        GetOneResult<TEntity> ReplaceOne(TEntity entity, string id);
        Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity, string id);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        ///         GetManyResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter);

        GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter);
        Task<GetOneResult<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter);
        GetOneResult<TEntity> DeleteById(string id);
        Task<GetManyResult<TEntity>> DeleteAsync(Expression<Func<TEntity, bool>> filter);
        Task<GetOneResult<TEntity>> DeleteByIdAsync(string id);
        void DeleteMany(Expression<Func<TEntity, bool>> filter);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);

    }
}
