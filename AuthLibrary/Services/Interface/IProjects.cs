using AuthLibrary.Dtos;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Services.Interface
{
    public interface IProjects
    {
        // Retrieves a collection of project entities from the database
        Task<ICollection<Projects>> GetAllProjects();

        // Retrieves a collection of project DTOs with specific information
        Task<ProjectDtos> GetProjectById(int projectid);

        // Adds a new project to the database
        Task<string> AddProject(ProjectDtos project);

        // Updates an existing project in the database
        Task<bool> UpdateProject(ProjectDtos project);

        // Deletes a project based on the provided DTO
        Task<bool> DeleteProject(ProjectDtos project);
    }
}
