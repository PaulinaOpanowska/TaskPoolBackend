using System;
using System.Collections.Generic;
using System.Text;
using TaskPoolBackend.Model.Models;

namespace TaskPoolBack.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private TaskPoolBackContext dbContext;

        public UnitOfWork(TaskPoolBackContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TaskPoolBackContext DbContext
        {
            get { return dbContext; }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
