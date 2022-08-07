using CoreLayer.Models;
using CoreLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public GetManyResult<TEntity> ASQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<GetManyResult<TEntity>> ASQueryableAsync()
        {
            throw new NotImplementedException();
        }
    }
}
