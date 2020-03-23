using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DbRepositories
{


    public abstract class Repository<T> : IRepository<T>
   where T : class
    {
        protected DbSet<T> _objectSet;

        public Repository(eShopContext context)
        {
            _objectSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _objectSet.Remove(entity);
        }

        public abstract T GetById(object id);


        public IEnumerable<T> GetAll()
        {
            return _objectSet;
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            return _objectSet.Where(filter);
        }

    }
}
