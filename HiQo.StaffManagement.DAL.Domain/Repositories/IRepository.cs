using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HiQo.StaffManagement.DAL.Domain.Repositories
{
    public interface IRepository
    {
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) where TEntity : class;

        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        TEntity GetById<TEntity>(int id) where TEntity : class;
        void SaveChanges();
    }
}