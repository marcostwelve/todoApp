using Entities.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllTasks(Expression<Func<T, bool>>? filter = null);
        Task<T> GetTaskById(int id, Expression<Func<T, bool>>? filter = null);
        Task CreateTask(T model);
        Task<T> UpdateTask(T model);
        Task<bool> DeleteTask(int id);
        Task<bool> SaveChangesAsync();
    }
}
