using AuthLibrary.Dtos;
using AuthLibrary.Services.Interface;
using AutoMapper;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjects _adminProject;
        private readonly IMapper _mapper;

        public ProjectController(IProjects adminProject, IMapper mapper)
        {
            _adminProject = adminProject;
            _mapper = mapper;
        }

        [HttpPost("Add-Project")]
        public async Task<ActionResult<string>> AddProject([FromBody] ProjectDtos projectDto)
        {
            if (projectDto == null)
            {
                return BadRequest("Invalid project data.");
            }

            var result = await _adminProject.AddProject(projectDto);
            return Ok(result);
        }

        [HttpGet("Get-All-Projects")]
        public async Task<ActionResult<ICollection<Projects>>> GetAllProjects()
        {
            var projects = await _adminProject.GetAllProjects();
            return Ok(projects);
        }


        [HttpGet("Get-Project")]
        public async Task<ActionResult<ProjectDtos>> GetProjectById(int id)
        {
            var project = await _adminProject.GetProjectById(id);

            if (project == null)
            {
                return NotFound("Project not found.");
            }

            return Ok(project);
        }

        [HttpPut("Update-Project-Status")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectDtos projectDto)
        {
            if (projectDto == null)
            {
                return BadRequest("Invalid project data.");
            }

            var isUpdated = await _adminProject.UpdateProject(projectDto);

            if (!isUpdated)
            {
                return NotFound("Project not found.");
            }

            return NoContent(); // 204 No Content response
        }

        [HttpDelete("Delete-Project")]
        public async Task<IActionResult> DeleteProject([FromBody] ProjectDtos projectDto)
        {
            if (projectDto == null)
            {
                return BadRequest("Invalid project data.");
            }

            var isDeleted = await _adminProject.DeleteProject(projectDto);

            if (!isDeleted)
            {
                return NotFound("Project not found.");
            }

            return NoContent(); // 204 No Content response
        }

    }
}
