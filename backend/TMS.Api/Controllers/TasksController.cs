using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;
        public TasksController(TaskService taskService)
        {
                _taskService = taskService; 
        }


        [HttpGet("allTasks")]
        [ProducesResponseType(typeof(List<Core.Models.Task>), 200)]
        public async Task<IActionResult> GetTasks()
        {
            var response = _taskService.GetAllTask();
            return Ok(response);
        }



        [HttpGet]
        [ProducesResponseType(typeof(List<Core.Models.Task>), 200)]
        public async Task<IActionResult> GetTasks(string status, string assignee)
        {
            var response = _taskService.GetTasksByStatusAndAssignee(status, assignee);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Core.Models.Task), 200)]
        public async Task<IActionResult> CreateTask(Core.Models.Task payload)
        {
            var response = await _taskService.CreateTask(payload);
            return Ok(response);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Core.Models.Task), 200)]
        public async Task<IActionResult> UpdateTask(Guid id, Core.Models.Task payload )
        {
            var response = await _taskService.UpdateTask(id, payload);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult>DeleteTask(Guid id)
        {
           var deleteResponse =  await _taskService.DeleteTask(id);
            return Ok(deleteResponse);

        }

       


    }
}
