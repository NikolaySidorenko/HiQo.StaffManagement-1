using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HiQo.StaffManagement.DAL.Context;

namespace HiQo.StaffManagement.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> /*: IBaseRepository<TEntity>*/ where TEntity : class
    {
        private readonly StaffManagementContext _context;
        private readonly IDbSet<TEntity> _dbSet;

        protected BaseRepository(StaffManagementContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null) query = query.Where(filter);

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Remove(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}