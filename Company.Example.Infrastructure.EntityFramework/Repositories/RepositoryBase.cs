using Company.Example.Core.Domain.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Company.Example.Infrastructure.EntityFramework.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
		protected RepositoryBase(ExampleDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

		protected ExampleDatabaseContext DatabaseContext { get; private set; }

        public virtual List<TEntity> FetchAll()
        {
            return DatabaseContext.Set<TEntity>().ToList();
        }

        public virtual void Add(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = DatabaseContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                DatabaseContext.Set<TEntity>().Attach(entity);
                entry.State = EntityState.Modified;
            }
        }

        public virtual TEntity Get(int id)
        {
            return DatabaseContext.Set<TEntity>().Find(id);
        }
    }
}