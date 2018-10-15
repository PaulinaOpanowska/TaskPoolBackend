using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TaskPoolBackend.Model.Models;

namespace TaskPoolBack.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private TaskPoolBackContext dataContext;
        public readonly DbSet<T> dbSet;

        protected TaskPoolBackContext DbContext
        {
            get { return dataContext; }
        }


        protected RepositoryBase(TaskPoolBackContext context)
        {
            dataContext = context;
            dbSet = DbContext.Set<T>();
        }

        protected RepositoryBase()
        {
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity, List<string> propertiesNotToUpdate = null)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;

            if (propertiesNotToUpdate != null)
            {
                foreach (var property in propertiesNotToUpdate)
                {
                    dataContext.Entry(entity).Property(property).IsModified = false;
                }
            }
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
    }
}
