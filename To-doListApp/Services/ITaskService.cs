using Microsoft.AspNetCore.Mvc;
using To_doListApp.Dtos;
using To_doListApp.Enums;
using To_doListApp.Models;

namespace To_doListApp.Services
{
    public interface ITaskService
    {
        Task<ServiceResponse<IEnumerable<TaskResponseDto>>> GetAllAsync(TaskQueryParameters queryParameters); // returns results in the same structured format.
        Task<ServiceResponse<TaskResponseDto>> GetByIdAsync(int id);
        Task<ServiceResponse<TaskItem>> CreateAsync(TaskCreateDto taskDto);
        Task<ServiceResponse<bool>> UpdateAsync(int id, TaskUpdateDto taskDto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<bool>> MarkAsCompleteAsync(int id);
    }
}
