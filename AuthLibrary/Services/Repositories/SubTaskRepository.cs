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
    public class SubTaskRepository : ISubTasks
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public SubTaskRepository(DataContext context, IMapper mapper) 
        { 
            _dataContext = context; 
            _mapper = mapper;
        }

        public async Task<string> AddSubTask(SubTasksDtos subTaskDto)
        {
            var subTask = _mapper.Map<SubTasks>(subTaskDto);
            await _dataContext.SubTask.AddAsync(subTask);
            await _dataContext.SaveChangesAsync();
            return "SubTask created successfully.";
        }

        public async Task<IEnumerable<SubTasksDtos>> GetAllSubTasks()
        {
            var subTasks = await _dataContext.SubTask.ToListAsync();
            return _mapper.Map<IEnumerable<SubTasksDtos>>(subTasks);
        }


        public async Task<IEnumerable<SubTasks>> GetSubTasksById(int subTaskId)
        {
            var subTask = await _dataContext.SubTask.FindAsync(subTaskId);
            return (IEnumerable<SubTasks>)_mapper.Map<SubTasksDtos>(subTask);
        }

        public async Task<bool> UpdateSubTask(int subTaskId)
        {
            var subTask = await _dataContext.SubTask.FindAsync(subTaskId);
            if (subTask == null) return false;

            // Assuming some update logic here, e.g., updating specific fields
            // subTask.SomeProperty = newValue;

            _dataContext.SubTask.Update(subTask);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSubTask(SubTasksDtos subTasks)
        {
            var subTask = await _dataContext.SubTask.FindAsync(subTasks.SubT_Id);
            if (subTask == null) return false;

            _dataContext.SubTask.Remove(subTask);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        
    }
}
