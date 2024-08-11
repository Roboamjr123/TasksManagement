using AuthLibrary.Dtos;
using AuthLibrary.Services.Interface;
using AutoMapper;
using DataLibrary.Database;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthLibrary.Services.Repositories
{
    public class ProjectsRepository(DataContext context, IMapper mapper) : IProjects
    {
        private readonly DataContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<string> AddProject(ProjectDtos project)
        {
            var newProject = _mapper.Map<Projects>(project);

            await _context.Project.AddAsync(newProject);
            await _context.SaveChangesAsync();

            return "Project added successfully";
        }

        public async Task<ProjectDtos> GetProjectById(int projectid)
        {
            var project = await _context.Project
                .Include(p => p.Task)
                .ThenInclude(t => t.SubTask)
                .ThenInclude(st => st.SubDetail)
                .FirstOrDefaultAsync(p=> p.Project_Id == projectid);

            if (project == null) return null;

            return _mapper.Map<ProjectDtos>(project);
        }


        public async Task<ICollection<Projects>> GetAllProjects()
        {
            return await _context.Project
                .Include(p => p.Task)
                .ThenInclude(t => t.SubTask)
                .ThenInclude(st => st.SubDetail)
                .ToListAsync();
        }

        public async Task<bool> UpdateProject(ProjectDtos project)
        {
            var existingProject = await _context.Project
                .FirstOrDefaultAsync(p => p.Project_Id == project.Project_Id);

            if (existingProject == null)
            {
                return false; // Project not found
            }

            _mapper.Map(project, existingProject);

            await _context.SaveChangesAsync();

            return true; // Update successful
        }


        public async Task<bool> DeleteProject(ProjectDtos project)
        {
            var projects = await _context.Project
                .FirstOrDefaultAsync(p => p.Project_Id == project.Project_Id);

            if (projects == null)
            {
                return false; // Project not found
            }

            _context.Project.Remove(projects);
            await _context.SaveChangesAsync();
            return true; // Successfully deleted
        }

       
    }
}
