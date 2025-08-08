using Entities.Models;
using Entities.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interface
{
    public interface IService
    {
        Task<IEnumerable<TasksDto>> GetAllTasks();
        Task<TasksDto> GetTaskById(int id);
        Task CreateTask(TasksDto model);
        Task<TasksDto> UpdateTask(int id, TasksDto model);
        Task<bool> DeleteTask(int id);
    }
}
