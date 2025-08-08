using Infrastruture.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Linq.Expressions;

namespace Infrastruture.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> _dbSet => _context.Set<T>();
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateTask(T model)
        {
            try
            {
                await _dbSet.AddAsync(model);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Um erro ocorreu ao tentar criar task.", ex);
            }
        }

        public async Task<bool> DeleteTask(int id)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

                task.IsDeleted = true;
                _context.Tasks.Update(task);
                return await SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro ocorreu ao tentar criar task com ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllTasks(Expression<Func<T, bool>>? filter = null)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                 return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Um erro ocorreu ao tentar buscar tasks.", ex);
            }
        }

        public async Task<T> GetTaskById(int id, Expression<Func<T, bool>>? filter = null)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                return await query.FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro ocorreu ao tentar buscar task com {id}.", ex);
            }
        }

        public async Task<T> UpdateTask(T model)
        {
            try
            {

                _dbSet.Update(model);
                await SaveChangesAsync();

                return model;

            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro ocorreu ao tentar atualizar task.", ex);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Um erro ocorreu ao tentar salvar task", ex);
            }
        }
    }
}
