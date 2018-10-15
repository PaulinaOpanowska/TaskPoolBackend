using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskPoolBack.Model.Models.DB;
using TaskPoolBackend.Model.Models;

namespace TaskPoolBack.Data.Infrastructure
{
    public static class DbInitializr
    {
        public static void Seed(TaskPoolBackContext context)
        {
            context.Database.Migrate();

            var users = new List<User>() {
                    new User{Name = "Name1", Surname = "Surname1"},
                    new User{Name = "Name2", Surname = "Surname2"},
                    new User{Name = "Name3", Surname = "Surname3"},
            };

            var tasks = new List<Task>() {
                    new Task{Name = "Task1"},
                    new Task{Name = "Task2"},
                    new Task{Name = "Task3"},
                    new Task{Name = "Task4"},
                    new Task{Name = "Task5"},
                    new Task{Name = "Task6"},
                    new Task{Name = "Task7"},
                    new Task{Name = "Task8"},
                    new Task{Name = "Task9"},
                    new Task{Name = "Task10"},
                    new Task{Name = "Task11"},
                    new Task{Name = "Task12"},
                    new Task{Name = "Task13"},
                    new Task{Name = "Task14"},
                    new Task{Name = "Task15"},
            };

            context.User.AddRange(users);
            context.Task.AddRange(tasks);
            context.SaveChanges();
        }
    }
}
