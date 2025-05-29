using To_doListApp.Dtos;
using To_doListApp.Enums;
using To_doListApp.Models;

namespace To_doListApp.Services
{
    public interface ITaskService
    {
        Task<ServiceResponse<IEnumerable<TaskItem>>> GetAllAsync(TodoStatus? status = null, TaskPriority? priority = null, DateTime? dueDate = null);
        Task<ServiceResponse<TaskItem>> GetByIdAsync(int id);
        Task<ServiceResponse<TaskItem>> CreateAsync(TaskCreateDto taskDto);
        Task<ServiceResponse<bool>> UpdateAsync(int id, TaskUpdateDto taskDto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<bool>> MarkAsCompleteAsync(int id);
    }
}
