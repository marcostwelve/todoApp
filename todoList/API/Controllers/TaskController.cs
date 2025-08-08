using AutoMapper;
using Entities.Models;
using Entities.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IService _service;
        private readonly IMapper _mapper;
        public TaskController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _service.GetAllTasks();
                if (tasks == null || !tasks.Any())
                {
                    return NotFound("Não há tasks criadas.");
                }
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest($"ID {id} inválido.");
                }
                var task = await _service.GetTaskById(id);
                if (task == null)
                {
                    return NotFound($"Task com ID {id} não encontrado.");
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TasksDto task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest("Necessário preencher os dados.");
                }
                await _service.CreateTask(task);
                return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TasksDto task)
        {
            try
            {
                if (task == null || id <= 0)
                {
                    return BadRequest("Task inválida");
                }
                var updatedTask = await _service.UpdateTask(id, task);
                if (updatedTask == null)
                {
                    return NotFound($"Task com ID {id} não encontrado.");
                }
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest($"ID {id} inválido.");
                }
                var isDeleted = await _service.DeleteTask(id);
                if (!isDeleted)
                {
                    return NotFound($"Task com ID {id} não encontrado.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }
    }
}
