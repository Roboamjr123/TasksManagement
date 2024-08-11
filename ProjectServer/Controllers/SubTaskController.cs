using AuthLibrary.Dtos;
using AuthLibrary.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        readonly private ISubTasks _subTask;
        readonly private IMapper _mapper;

        public SubTaskController(ISubTasks subTasks, IMapper mapper)
        {
            _subTask = subTasks;
            _mapper = mapper;
        }

        [HttpPost("Add-SubTask")]
        public async Task<IActionResult> AddSubTask([FromBody] SubTasksDtos subTaskDto)
        {
            if (subTaskDto == null)
            {
                return BadRequest("Invalid Task data.");
            }

            var result = await _subTask.AddSubTask(subTaskDto);
            return Ok(result);
        }

        [HttpGet("Get-All-SubTask")]
        public async Task<IActionResult> GetAllSubTasks()
        {
            var subTask = await _subTask.GetAllSubTasks();
            var SubTaskDtos = _mapper.Map<IEnumerable<TasksDtos>>(subTask);
            return Ok(SubTaskDtos);
        }

        [HttpGet("Get-SubTask")]
        public async Task<IActionResult> GetSubTaskById(int id)
        {
            var subTask = await _subTask.GetSubTasksById(id);
            if (subTask == null)
            {
                return NotFound();
            }

            return Ok(subTask);
        }

        [HttpPut("Update-SubTask")]
        public async Task<IActionResult> UpdateSubTask(int subTaskId)
        {
            var success = await _subTask.UpdateSubTask(subTaskId);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpDelete("Delete-SubTask")]
        public async Task<IActionResult> DeleteSubTask(int id)
        {
            var subTaskDto = new SubTasksDtos { SubT_Id = id };
            var success = await _subTask.DeleteSubTask(subTaskDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }





    }

}
