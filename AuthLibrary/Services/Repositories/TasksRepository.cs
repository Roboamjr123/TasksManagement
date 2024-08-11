using AuthLibrary.Dtos;
using AuthLibrary.Services.Interface;
using AutoMapper;
using DataLibrary.Database;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Services.Repositories
{

    public class TasksRepository : ITasks
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TasksRepository (DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<string> AddTasks(TasksDtos taskDto)
        {
            // Ensure the related project exists
            var project = await _context.Project.FindAsync(taskDto.Project_Id);
            if (project == null)
            {
                throw new ArgumentException("Project not found");
            }

            // Create a new task entity
            var task = new Tasks
            {
                Project_Id = taskDto.Project_Id.Value, // Use Value if nullable
                Task_Name = taskDto.Task_Name,
                PlannedStartDate = taskDto.PlannedStartDate,
                PlannedEndDate = taskDto.PlannedEndDate,
                ActualStartDate = taskDto.ActualStartDate,
                ActualEndDate = taskDto.ActualEndDate,
             
            };

            // Add the task to the context
            _context.Task.Add(task);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the new task ID
            return task.Task_Id.ToString();
        }

        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            return await _context.Task.ToListAsync();
        }

        public async Task<TasksDtos> GetTaskById(int id)
        {
            var task = await _context.Task
                                     .Include(t => t.Project)
                                     .FirstOrDefaultAsync(t => t.Task_Id == id);
            return _mapper.Map<TasksDtos>(task);
        }

        public async Task<bool> DeleteTasks(TasksDtos taskDto)
        {
            var task = await _context.Task.FindAsync(taskDto.Task_Id);
            if (task == null)
                return false;

            _mapper.Map(taskDto, task);

            _context.Task.Update(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateTasks(TasksDtos taskDto)
        {
            var task = await _context.Task.FindAsync(taskDto.Task_Id);
            if (task == null)
                return false;

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}

