using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;

namespace TaskManagementSystem.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;
        public ToDoTaskController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        [HttpGet]
        [Route("GetAllToDoTask")]
        public async Task<IActionResult> GetAllToDoTask()
        {
            var toDoTask = await _toDoTaskService.GetAllToDoTaskAsync();
            return Ok(toDoTask);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoTaskById(int id)
        {
            var toDoTask = await _toDoTaskService.GetToDoTaskByIdAsync(id);
            return Ok(toDoTask);
        }

        [HttpPost]
        [Route("AddToDoTask")]
        public async Task<ActionResult<ToDoTask>> AddToDoTask(ToDoTaskDTO toDoTaskDto)
        {
            var newTasks = await _toDoTaskService.AddToDoTaskAsync(toDoTaskDto);
            return Ok(newTasks);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoTask(ToDoTaskDTO toDoTaskDto, int id)
        {
            await _toDoTaskService.UpdateToDoTaskAsync(toDoTaskDto,id);
            return Ok(toDoTaskDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoTask(int id)
        {
            await _toDoTaskService.DeleteToDoTaskAsync(id);
            return Ok();
        }


    }
}
