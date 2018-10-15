
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskPoolBack.Model.Models.DB;
using TaskPoolBackend.Model.Models;

namespace TaskPoolBackend.Model.Models
{
    public class TaskPoolBackContext : DbContext
    {
        public TaskPoolBackContext(DbContextOptions<TaskPoolBackContext> options)
            : base(options)
        { }

        public DbSet<Task> Task { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Task>(config =>
            {
                config.ToTable("Task")
                .HasIndex(u => u.Name)
                .IsUnique();
            });

            modelBuilder.Entity<User>(config =>
            {
                config.ToTable("User");
            });
        }

        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
