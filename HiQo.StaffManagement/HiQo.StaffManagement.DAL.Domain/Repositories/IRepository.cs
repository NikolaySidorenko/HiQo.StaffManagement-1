using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HiQo.StaffManagement.DAL.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
    }
}