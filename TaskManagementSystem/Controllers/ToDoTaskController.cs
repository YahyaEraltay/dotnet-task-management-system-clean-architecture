using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;

namespace TaskManagementSystem.API.Controllers
{
    //[Authorize]
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
            var toDoTask = await _toDoTaskService.GetAllToDoTaskAync();
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
        public async Task<ActionResult<ToDoTask>> AddToDoTask([FromBody] ToDoTaskRequestDTO request)
        {
            var newTasks = await _toDoTaskService.AddToDoTaskAsync(request);
            return Ok(newTasks);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoTask(ToDoTaskDTO toDoTaskDto, int id)
        {
            await _toDoTaskService.UpdateToDoTaskAsync(toDoTaskDto, id);
            return Ok(toDoTaskDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteToDoTask([FromBody] DeleteToDoTaskRequestDTO request)
        {
            await _toDoTaskService.DeleteToDoTaskAsync(request);
            return Ok();
        }


    }
}
