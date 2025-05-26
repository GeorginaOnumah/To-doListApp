using To_doListApp.Data;
using To_doListApp.Enums;
using To_doListApp.Models;

namespace To_doListApp.Seed
{
        public static class DbSeeder
        {
            public static void Seed(TodoDbContext context)
            {
                // Check if tasks already exist to avoid duplicates
                if (!context.Tasks.Any())
                {
                    context.Tasks.AddRange(
                        new TaskItem
                        {
                            Title = "Setup project",
                            Description = "Initialize the .NET project and configure database",
                            DueDate = DateTime.Now.AddDays(3),
                            Status = TodoStatus.Pending,
                            Priority = TaskPriority.Medium
                        },
                        new TaskItem
                        {
                            Title = "Create Models",
                            Description = "Define the data models for the project",
                            DueDate = DateTime.Now.AddDays(5),
                            Status = TodoStatus.Pending,
                            Priority = TaskPriority.High
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
}
