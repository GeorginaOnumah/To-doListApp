using To_doListApp.Enums;
using To_doListApp.Models;

namespace To_doListApp.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync(TodoStatus? status = null, TaskPriority? priority = null, DateTime? dueDate = null);
        Task<TaskItem> GetByIdAsync(int id);
        Task<TaskItem> CreateAsync(TaskItem task);
        Task<bool> UpdateAsync(TaskItem task);
        Task<bool> DeleteAsync(TaskItem task);
    }
}
