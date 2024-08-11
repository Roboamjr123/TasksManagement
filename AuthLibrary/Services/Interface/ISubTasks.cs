
using AuthLibrary.Dtos;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Services.Interface
{
    public interface ISubTasks
    {
        Task<IEnumerable<SubTasksDtos>> GetAllSubTasks();
        Task<IEnumerable<SubTasks>> GetSubTasksById(int subTaskId); 
        Task<string> AddSubTask(SubTasksDtos subTasks);
        Task<bool> UpdateSubTask(int subTaskId);
        Task<bool> DeleteSubTask(SubTasksDtos subTasks);


    }
}
