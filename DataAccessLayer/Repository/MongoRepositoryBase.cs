﻿using CoreLayer.Models;
using CoreLayer.Repository.Abstract;
using CoreLayer.Settings;
using DataAccessLayer.Context;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly MongodbContext _context;
        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepositoryBase(IOptions<MongoSettings> settings)
        {
            _context = new MongodbContext(settings);
            _collection = _context.GetCollection<TEntity>();
        }

        public GetManyResult<TEntity> ASQueryable()
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = _collection.AsQueryable().ToList();
                if (data != null)
                    result.Result = data;
                {

                }
            }
            catch (Exception ex)
            {

                result.Message = $"AsQueryable {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public async Task<GetManyResult<TEntity>> ASQueryableAsync()
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = await _collection.AsQueryable().ToListAsync();
                if (data != null)
                    result.Result = data;
                {

                }
            }
            catch (Exception ex)
            {

                result.Message = $"AsQueryable {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = _collection.Find(filter).ToList();
                if (data != null)
                    result.Result = data;
                {

                }
            }
            catch (Exception ex)
            {

                result.Message = $"FilterBy {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public async Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = await _collection.Find(filter).ToListAsync();
                if (data != null)
                    result.Result = data;
                {

                }
            }
            catch (Exception ex)
            {

                result.Message = $"FilterBy {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public GetOneResult<TEntity> GetById(string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = _collection.Find(filter).FirstOrDefault();
                if (data != null)
                    result.Entity = data;
              
         
               
            }
            catch (Exception ex)
            {

                result.Message = $"AsQueryable {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public async Task<GetOneResult<TEntity>> GetByIdAsync(string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = await _collection.Find(filter).FirstOrDefaultAsync();
                if (data != null)
                    result.Entity = data;



            }
            catch (Exception ex)
            {

                result.Message = $"AsQueryable {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public GetOneResult<TEntity> InsertOne(TEntity entity)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                _collection.InsertOne(entity);
                result.Entity = entity; 

            }
            catch (Exception ex)
            {

                result.Message = $"InsertOne {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public async Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity)
        {
            var result =  new GetOneResult<TEntity>();
            try
            {
               await _collection.InsertOneAsync(entity);
                result.Entity = entity;

            }
            catch (Exception ex)
            {

                result.Message = $"InsertOneAsync {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
    }
    
}
