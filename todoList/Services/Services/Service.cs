using AutoMapper;
using Entities.Models;
using Entities.Models.Dto;
using Infrastruture.Repository.Interface;
using Services.Services.Interface;

namespace Services.Services
{
    public class Service : IService
    {
        private readonly IRepository<Tasks> _repository;
        private readonly IMapper _mapper;
        public Service(IRepository<Tasks> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateTask(TasksDto model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model), "Modelo de criação inválido.");
                }

                var modelEntity = _mapper.Map<Tasks>(model);
                await _repository.CreateTask(modelEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Um erro ocorreu ao tentar criar task", ex);
            }
        }

        public async Task<bool> DeleteTask(int id)
        {

            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "ID não pode ser menor igual a 0.");
                }
                return await _repository.DeleteTask(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro ocorreu ao tentar deletar uma task {id}.", ex);
            }
        }

        public async Task<IEnumerable<TasksDto>> GetAllTasks()
        {
            try
            {
                var tasksdto = _repository.GetAllTasks(x => x.IsDeleted == false);
                var result = _mapper.Map<IEnumerable<TasksDto>>(await tasksdto);
                return result; 

            }
            catch (Exception ex)
            {
                throw new Exception("Um erro ocorreu ao tentar buscar tasks.", ex);
            }
        }

        public async Task<TasksDto> GetTaskById(int id)
        {
            try
            {
                var task = await _repository.GetTaskById(id, x => x.IsDeleted == false);

                var result = _mapper.Map<TasksDto>(task);
                return result;
            }
            catch (Exception ex)
            {
               throw new Exception($"Um erro ocorreu ao tentar buscar task {id}.", ex);
            }
        }

        public async Task<TasksDto> UpdateTask(int id, TasksDto model)
        {
            try
            {
                if (id < 1 || model == null)
                {
                    throw new ArgumentException("ID ou model incorreto.");
                }
                var existingTask = await _repository.GetTaskById(id, x => x.IsDeleted == false);
                if (existingTask == null)
                {
                    throw new KeyNotFoundException($"Task com ID {id} não encontrada.");
                }
                if (existingTask.IsDeleted)
                {
                    throw new InvalidOperationException($"Task com ID {id} está deletada.");
                }
                existingTask.IsCompleted = model.IsCompleted;
                var modelEntity = _mapper.Map<Tasks>(existingTask);

                await _repository.UpdateTask(modelEntity);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro ocorreu ao tentar atualizar task { id}.", ex);
            }
        }
    }
}
