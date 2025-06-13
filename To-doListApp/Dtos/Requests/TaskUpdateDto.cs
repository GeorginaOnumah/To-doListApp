﻿using System.ComponentModel.DataAnnotations;
using To_doListApp.Enums;

namespace To_doListApp.Dtos
{
    public class TaskUpdateDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; } 

        //[Required]
        //[EnumDataType(typeof(TaskPriority))]
        public TaskPriority? Priority { get; set; }

        //[Required]
        //[EnumDataType(typeof(TodoStatus))]
        public TodoStatus? Status { get; set; }
    }
}
