using Microsoft.EntityFrameworkCore;
using System;
using To_doListApp.Models;

namespace To_doListApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options) { }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
