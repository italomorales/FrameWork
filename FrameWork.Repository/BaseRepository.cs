using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FrameWork.Repository
{
    
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        TEntity GetById(long id);
        TEntity GetById(int id);
        TEntity GetById(string id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, int? quantity = null);
        int Count();
        TEntity Get(Expression<Func<TEntity, bool>> where);
        void Commit();
    }

    public abstract class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity> where TContext : DbContext
        where TEntity : class
    {
       
        protected string ConnectionString { get; set; }

        public DbSet<TEntity> DbSet;
        public TContext DataContext;

        #region Add        
        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }
        #endregion

        #region Update
        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }
        #endregion

        #region Delete
        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
        #endregion

        #region Delete
        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            var objects = DbSet.Where(where).AsEnumerable();

            foreach (var obj in objects)
                DbSet.Remove(obj);
        }
        #endregion

        #region GetById
        public virtual TEntity GetById(long id)
        {
            return DbSet.Find(id);
        }
        #endregion

        #region GetById
        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }
        #endregion

        #region GetById
        public virtual TEntity GetById(string id)
        {
            return DbSet.Find(id);
        }
        #endregion

        #region GetAll
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        #endregion

        #region GetMany
        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, int? quantity = null)
        {
            return quantity.HasValue ? DbSet.Where(@where).Take(quantity.Value).ToList() : DbSet.Where(@where).ToList();
        }
        #endregion

        #region Count
        public virtual int Count()
        {
            return DbSet.Count();
        }
        #endregion

        #region Get
        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where).FirstOrDefault();
        }
        #endregion

        #region Commit
        public virtual void Commit()
        {
            DataContext.SaveChanges();
        }
        #endregion
    }
}