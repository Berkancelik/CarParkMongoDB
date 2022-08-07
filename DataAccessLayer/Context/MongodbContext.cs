﻿using CoreLayer.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class MongodbContext
    {
        private readonly IMongoDatabase _database;

        public MongodbContext(IOptions<MongoSettings>settings)
        {
            var client = new MongoClient(settings.Value.ConnectionStrings);
            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
