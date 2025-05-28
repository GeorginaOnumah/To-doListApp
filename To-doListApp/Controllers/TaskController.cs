using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_doListApp.Dtos;
using To_doListApp.Enums;
using To_doListApp.Services;

namespace To_doListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] TodoStatus? status, [FromQuery] TaskPriority? priority, [FromQuery] DateTime? dueDate)
        {
            var tasks = await _taskService.GetAllAsync(status, priority, dueDate);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                _logger.LogWarning("Task with id {Id} not found", id);
                return NotFound(new { Message = $"Task with id {id} not found." });
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TaskCreateDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTask = await _taskService.CreateAsync(taskDto);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TaskUpdateDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _taskService.UpdateAsync(id, taskDto);
            if (!updated)
            {
                _logger.LogWarning("Attempt to update non-existent task with id {Id}", id);
                return Ok(new { success = false, message = $"Task with id {id} not found." });
            }

            return Ok(new { success = true });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _taskService.DeleteAsync(id);
            if (!deleted)
            {
                _logger.LogWarning("Attempt to delete non-existent task with id {Id}", id);
                return Ok(new{ success = false, message = $"Task with id {id} not found." });
            }

            return Ok(new { success = true });
        }

        [HttpPost("{id}/complete")]
        public async Task<ActionResult> MarkAsComplete(int id)
        {
            var marked = await _taskService.MarkAsCompleteAsync(id);
            if (!marked)
            {
                _logger.LogWarning("Attempt to mark non-existent task as complete with id {Id}", id);
                return Ok(new { success = false, message = $"Task with id {id} not found." });
            }

            return Ok(new { success = true });
        }
    }
}
