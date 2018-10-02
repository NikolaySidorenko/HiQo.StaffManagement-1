using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Exceptions;
using HiQo.StaffManagement.Settings;

namespace HiQo.StaffManagement.DAL.Repositories
{
    public class Repository : IRepository
    {
        private readonly StaffManagementContext _context;
        private readonly IRequestIdProvider _requestId;

        public Repository(StaffManagementContext context, IRequestIdProvider requestId)
        {
            _context = context;
            _requestId = requestId;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<TEntity>().Add(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            //_context.Set<TEntity>().Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;

            _context.Set<TEntity>().AddOrUpdate(entity);
        }

        public IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById<TEntity>(int id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Delete<TEntity>(TEntity entityToDelete) where TEntity : class
        {
            if (entityToDelete is null)
            {
                throw new ArgumentNullException(nameof(entityToDelete));
            }

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entityToDelete);
            }

            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (SaveChangesException exception) //Network safe  // TODO:Custom exception
            {
                var a = _requestId.GetRequestId();
                //Log
                throw;
            }
            catch (Exception exception)
            {
                //TODO:Log?
                throw new Exception(exception.Message);
            }
        }
    }
}