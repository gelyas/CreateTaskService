using GenerateGuidService.Models;
using GenerateGuidService.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenerateGuidService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost(Name = "task")]
        public async Task<IActionResult> CreateTask()
        {
            var numberTask = await _taskService.CreateTaskAsync();

            if (numberTask == Guid.Empty)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            //TODO вынести в другой поток обновление кода
            var outer = Task.Run(async () =>      // внешняя задача
            {
                await _taskService.UpdateTaskStateAsync(numberTask, "running");

                await Task.Delay(5000);

                await _taskService.UpdateTaskStateAsync(numberTask, "finished");
            });

            //outer.Start();
            return Accepted(@$"{numberTask}", numberTask);
        }

        [HttpGet()]
        public async Task<IActionResult> GetTask(string id)
        {
            Guid guidOutput;

            if (!Guid.TryParse(id, out guidOutput))
                return BadRequest("Передан не GUID");

            var getState = await _taskService.GetTaskByIdAsync(guidOutput);

            if (getState != null)
                return Ok(getState);
            else return NotFound("Нет такой задачи");
        }
    }
}
