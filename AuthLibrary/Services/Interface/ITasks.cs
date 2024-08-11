using AuthLibrary.Dtos;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Services.Interface
{
    public interface ITasks
    {
        // Retrieves a collection of task entities from the database
        Task<IEnumerable<Tasks>> GetAllTasks();

        // Retrieves a specific task DTO by its ID
        Task<TasksDtos> GetTaskById(int id);

        // Adds a new task to the database
        Task<string> AddTasks(TasksDtos taskDto);

        // Updates an existing task in the database
        Task<bool> UpdateTasks(TasksDtos taskDto);

        // Deletes a task based on the provided ID
        Task<bool> DeleteTasks(TasksDtos taskDto);

    }
}
