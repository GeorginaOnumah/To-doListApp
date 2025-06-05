using System.ComponentModel.DataAnnotations;// helps you validate data
using To_doListApp.Enums;

namespace To_doListApp.Dtos
{
    public class TaskCreateDto
    {
            [Required]
            public string Title { get; set; }

            public string? Description { get; set; }

            public DateTime? DueDate { get; set; }

            [Required]
            [EnumDataType(typeof(TaskPriority))]
            public TaskPriority Priority { get; set; }
    }
}
