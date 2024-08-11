using AuthLibrary.Dtos;
using AuthLibrary.Services.Interface;
using AuthLibrary.Services.Repositories;
using AutoMapper;
using DataLibrary.Database;
using Microsoft.AspNetCore.Mvc;

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasks _tasks;
        private readonly IMapper _mapper;

        public TasksController(ITasks tasks, IMapper mapper)
        {
            _tasks = tasks;
            _mapper = mapper;   
        }

        [HttpPost("Add-Task")]
        public async Task<ActionResult<string>> AddTasks([FromBody] TasksDtos taskDto)
        {
            if (taskDto == null)
            {
                return BadRequest("Invalid Task data.");
            }

            var result = await _tasks.AddTasks(taskDto);
            return Ok(result);
        }

        [HttpGet("Get-All-Tasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _tasks.GetAllTasks();
            var taskDtos = _mapper.Map<IEnumerable<TasksDtos>>(tasks);
            return Ok(taskDtos);
        }

        [HttpGet("Get-Task")]
        public async Task<ActionResult<TasksDtos>> GetTaskById(int id)
        {
            var task = await _tasks.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }


        [HttpPut("Update-Task-Status")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TasksDtos taskDto)
        {
            if (id != taskDto.Task_Id)
            {
                return BadRequest("Task ID mismatch.");
            }

            var updated = await _tasks.UpdateTasks(taskDto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("Delete-Task")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = new TasksDtos { Task_Id = id };
            var deleted = await _tasks.DeleteTasks(task);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
