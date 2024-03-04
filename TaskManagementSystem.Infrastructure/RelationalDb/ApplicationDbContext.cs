using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.RelationalDb
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ToDoTask> ToDoTask { get; set; }
        public ApplicationDbContext(string connectionString) : base(BuildDbContextOptions(connectionString))
        {
        }
        public static DbContextOptions<ApplicationDbContext> BuildDbContextOptions(string connectionString)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return dbContextOptionsBuilder.Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
        .        HasOne(t => t.AssignedUser)
                .WithMany() 
                .HasForeignKey(t => t.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
