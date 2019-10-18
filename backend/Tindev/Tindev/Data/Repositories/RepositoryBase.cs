using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Tindev.Data.Context;
using Tindev.Interfaces;

namespace Tindev.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DbContext Contexto;
        public RepositoryBase()
        {
            Contexto = new TindevContext();
        }

        protected void Commit()
        {
            Contexto.SaveChanges();
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return Contexto.Set<TEntity>(); }
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
            Commit();
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }
        public virtual TEntity GetByIdReadOnly(Guid id)
        {
            TEntity entity = DbSet.Find(id);
            if (entity != null)
                Contexto.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public virtual IEnumerable<TEntity> GetAllReadOnly()
        {
            return DbSet.AsNoTracking();
        }

        public virtual void Update(TEntity obj)
        {
            var entry = Contexto.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Remove(TEntity obj)
        {
            var entry = Contexto.Entry(obj);

            if (!DbSet.Local.Any(e => e == obj))
                DbSet.Attach(obj);

            entry.State = EntityState.Deleted;
        }
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }


    }
}