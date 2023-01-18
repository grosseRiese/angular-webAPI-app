using Microsoft.EntityFrameworkCore;
using ToDoListTask.Models;
using ToDoListTask.DTOs;

namespace ToDoListTask.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoCategory>().HasData(
                new ToDoCategory { Id = 1, Name = "Important" },
                new ToDoCategory { Id = 2, Name = "Completed" },
                new ToDoCategory { Id = 3, Name = "Deleted" }
            );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoCategory> ToDoCategories { get; set; }
      
    }
}