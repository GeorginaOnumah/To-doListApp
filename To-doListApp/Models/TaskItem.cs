using System.ComponentModel.DataAnnotations; // helps you validate data
using System.Threading.Tasks;
using To_doListApp.Enums;

namespace To_doListApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        [Required]
        public TodoStatus Status { get; set; }
        [Required]
        public TaskPriority Priority { get; set; }
        public TaskItem() { } // Constructor for new task items or updating task items

        //constructor for creating a new task item with required fields and setting all the main details at once.
        public TaskItem(string title, string description, DateTime? dueDate, TodoStatus status, TaskPriority priority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
        }
    }
}
