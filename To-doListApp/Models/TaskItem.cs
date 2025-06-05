using To_doListApp.Enums;

namespace To_doListApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TodoStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskItem() { } // Constructor for new task items or updating task items

        //constructor for creating a new task item with required fields and setting all the main details at once.
        public TaskItem(string Title, string Description, DateTime DueDate, TodoStatus Status, TaskPriority Priority)
        {
            Title = Title;
            Description = Description;
            DueDate = DueDate;
            Status = Status;
            Priority = Priority;
        }
    }
}
