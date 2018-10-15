using System;
using System.Collections.Generic;
using System.Text;
using TaskPoolBack.Data.Infrastructure;
using TaskPoolBack.Model.Models.DB;
using TaskPoolBackend.Model.Models;

namespace TaskPoolBack.Data.Repositories
{
    public class TaskRepository : RepositoryBase<Task>, ITaskReporitory
    {
        public TaskRepository(TaskPoolBackContext context) : base(context)
        {

        }
    }

    public interface ITaskReporitory : IRepository<Task>
    {
    }
}
