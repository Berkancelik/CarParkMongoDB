using CoreLayer.Models;
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
        GetManyResult<TEntity> ASQueryable();
        Task<GetManyResult<TEntity>> ASQueryableAsync();
        GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);
        GetOneResult<TEntity> GetById(string id);
        Task<GetOneResult<TEntity>> GetByIdAsync(string id);
    }
}
