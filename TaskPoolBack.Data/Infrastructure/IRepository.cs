﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TaskPoolBack.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        void Add(T entity);
        void Update(T entity, List<string> propertiesNotToUpdate = null);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
    }
}
