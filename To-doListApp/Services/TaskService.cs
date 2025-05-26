using AutoMapper;
using To_doListApp.Dtos;
using To_doListApp.Enums;
using To_doListApp.Models;
using To_doListApp.Repositories;

namespace To_doListApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            var task = _mapper.Map<TaskItem>(taskDto);
            return await _repository.CreateAsync(task);
        }

        public async Task<bool> UpdateAsync(int id, TaskUpdateDto taskDto)
        {
            var existingTask = await _repository.GetByIdAsync(id);
            if (existingTask == null) return false;

            _mapper.Map(taskDto, existingTask);
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
