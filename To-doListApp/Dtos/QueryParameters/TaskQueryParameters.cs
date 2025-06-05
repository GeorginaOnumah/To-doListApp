using System.ComponentModel.DataAnnotations;// helps you validate data
using Microsoft.AspNetCore.Mvc;
using To_doListApp.Enums;

namespace To_doListApp.Dtos
{
    public class TaskQueryParameters
    {
        public TodoStatus? status { get; set; }
        public TaskPriority? priority { get; set; }
        public DateTime? dueDate { get; set; }
    }
}
