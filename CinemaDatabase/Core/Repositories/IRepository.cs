using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CinemaDatabase.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetDetailed(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }


}
