using To_doListApp.Dtos;
using To_doListApp.Enums;
using To_doListApp.Models;
using To_doListApp.Repositories;

namespace To_doListApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync(TodoStatus? status = null, TaskPriority? priority = null, DateTime? dueDate = null)
        {
            return await _repository.GetAllAsync(status, priority, dueDate);
        }

        public async Task<TaskItem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TaskItem> CreateAsync(TaskCreateDto taskDto)
        {
            var task = new TaskItem
            { 
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Priority = taskDto.Priority,
                Status = taskDto.Status
            };

            return await _repository.CreateAsync(task);
        }

        public async Task<bool> UpdateAsync(int id, TaskUpdateDto taskDto)
        {
            var existingTask = await _repository.GetByIdAsync(id);
            if (existingTask == null) return false;

            existingTask.Title = taskDto.Title;
            existingTask.Description = taskDto.Description;
            existingTask.DueDate = taskDto.DueDate;
            existingTask.Priority = taskDto.Priority;
            existingTask.Status = taskDto.Status;

            await _repository.UpdateAsync(existingTask);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingTask = await _repository.GetByIdAsync(id);
            if (existingTask == null) return false;

            await _repository.DeleteAsync(existingTask);
            return true;
        }

        public async Task<bool> MarkAsCompleteAsync(int id)
        {
            var existingTask = await _repository.GetByIdAsync(id);
            if (existingTask == null) return false;

            existingTask.Status = TodoStatus.Completed;
            await _repository.UpdateAsync(existingTask);
            return true;
        }
    }
}
