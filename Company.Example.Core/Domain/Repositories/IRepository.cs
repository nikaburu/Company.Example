using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Example.Core.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> FetchAll();

        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity proposal);

        TEntity Get(int id);
        //ICollection<TEntity> GetMany(int[] ids);
    }
}
