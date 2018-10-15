using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskPoolBack.Data.Infrastructure;
using TaskPoolBack.Model.Models.DB;
using TaskPoolBackend.Model.Models;

namespace TaskPoolBack.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(TaskPoolBackContext context) : base(context)
        {

        }

        public IEnumerable<User> GetAllUser()
        {
            return dbSet.Include(x => x.Tasks).OrderByDescending(x => x.Tasks.Count());
        }

        public User GetUserById(int id)
        {
            return dbSet.Include(x => x.Tasks).SingleOrDefault(x => x.Id == id);
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
    }
}
