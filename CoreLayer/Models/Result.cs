using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Result
    {
        public bool  Success { get; set; }
        public string Message { get; set; }
    }

    public class GetOneResult<TEntity>:Result where TEntity :class,new()
    {
        public TEntity Entity { get; set; }

    }

    public class GetManyResult<TEntity> : Result where TEntity : class, new (){
        public IEnumerable<TEntity> Result { get; set; }
    }


}
