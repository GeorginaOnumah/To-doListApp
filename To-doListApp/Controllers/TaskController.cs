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
        public async Task<ActionResult> GetAll([FromQuery] TaskQueryParameters queryParameters)
        {
            var response = await _taskService.GetAllAsync(queryParameters);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var response = await _taskService.GetByIdAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TaskCreateDto taskDto)
        {
            var response = await _taskService.CreateAsync(taskDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TaskUpdateDto taskDto)
        {
            var response = await _taskService.UpdateAsync(id, taskDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _taskService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpPost("{id}/complete")]
        public async Task<ActionResult> MarkAsComplete(int id)
        {
            var response = await _taskService.MarkAsCompleteAsync(id);
            return Ok(response);
        }
    }
}
