using System.ComponentModel.DataAnnotations;// helps you validate data
using To_doListApp.Enums;

namespace To_doListApp.Dtos
{
    public class TaskResponseDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public TodoStatus Status { get; set; }
    }
}
