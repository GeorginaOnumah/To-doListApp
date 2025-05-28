using To_doListApp.Dtos;
using To_doListApp.Enums;
using To_doListApp.Models;

namespace To_doListApp.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync(TodoStatus? status = null, TaskPriority? priority = null, DateTime? dueDate = null); //getting a list of all task and for filtering
        Task<TaskItem> GetByIdAsync(int id);
        Task<TaskItem> CreateAsync(TaskCreateDto taskDto);
        Task<bool> UpdateAsync(int id, TaskUpdateDto taskDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> MarkAsCompleteAsync(int id);
    }
}
