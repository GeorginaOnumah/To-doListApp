using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using To_doListApp.Dtos;
using To_doListApp.Enums;
using To_doListApp.Models;
using To_doListApp.Repositories;

namespace To_doListApp.Services //receives request from the controller and interacts with the database using the repository pattern
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

        public async Task<ServiceResponse<IEnumerable<TaskItem>>> GetAllAsync(TaskQueryParameters queryParameters)
        {
            var tasks = await _repository.GetAllAsync(queryParameters.status, queryParameters.priority, queryParameters.dueDate);
            return new ServiceResponse<IEnumerable<TaskItem>>
            {
                Data = tasks,
                Success = tasks.Any(),
                Message = tasks.Any() ? null : "No tasks found for this filter."
            };
        }

        public async Task<ServiceResponse<TaskItem>> GetByIdAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            return new ServiceResponse<TaskItem>
            {
                Data = task,
                Success = task != null,
                Message = task != null ? null : $"Task with id {id} not found."
            };
        }

        public async Task<ServiceResponse<TaskItem>> CreateAsync(TaskCreateDto taskDto)
        {
            var task = _mapper.Map<TaskItem>(taskDto);
            task.Status = TodoStatus.Pending;//this is for new tasks, they start as pending
            var created = await _repository.CreateAsync(task);

            return new ServiceResponse<TaskItem> { Data = created };
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(int id, TaskUpdateDto taskDto)
        {
            var response = new ServiceResponse<bool>();
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
            {
                response.Success = false;
                response.Message = $"Task with id {id} not found.";
                response.Data = false;
                return response;
            }

            // Only update fields that are provided in the DTO
            if (taskDto.Title != null)
                task.Title = taskDto.Title;

            if (taskDto.Description != null)
                task.Description = taskDto.Description;

            if (taskDto.DueDate.HasValue)
                task.DueDate = taskDto.DueDate;

            if (taskDto.Priority.HasValue)
                task.Priority = taskDto.Priority.Value;

            if (taskDto.Status.HasValue)
                task.Status = taskDto.Status.Value;

            var updateResult = await _repository.UpdateAsync(task);

            response.Data = updateResult;
            response.Success = updateResult;
            response.Message = updateResult ? "Task updated successfully." : "Task update failed.";

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = $"Task with id {id} not found.", Data = false };
            }

            await _repository.DeleteAsync(task);
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> MarkAsCompleteAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = $"Task with id {id} not found.", Data = false };
            }

            task.Status = TodoStatus.Completed;
            await _repository.UpdateAsync(task);
            return new ServiceResponse<bool> { Data = true };
        }
    }
 }
