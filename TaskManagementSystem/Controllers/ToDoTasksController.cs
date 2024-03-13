using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel;

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

        [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            var toDoTask = await _toDoTaskService.GetAllToDoTaskAync();

            return Ok(toDoTask);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Detail([FromBody] GetToDoTaskByIdRequestDTO request)
        {
            var toDoTask = await _toDoTaskService.GetToDoTaskByIdAsync(request);

            return Ok(toDoTask);
        }

        [HttpPost("[action]")]      
        public async Task<ActionResult<ToDoTask>> Create([FromBody] ToDoTaskRequestDTO request)
        {
            var newTasks = await _toDoTaskService.AddToDoTaskAsync(request);

            return Ok(newTasks);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateToDoTaskRequestDTO request)
        {
           var toDoTask = await _toDoTaskService.UpdateToDoTaskAsync(request);

            return Ok(toDoTask);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteToDoTaskRequestDTO request)
        {
            await _toDoTaskService.DeleteToDoTaskAsync(request);

            return Ok();
        }


    }
}
