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
        public async Task<ActionResult<GetToDoTaskResponseDTO>> All()
        {
            var toDoTask = await _toDoTaskService.All();

            return Ok(toDoTask);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<GetToDoTaskResponseDTO>> Detail([FromBody] GetToDoTaskIdRequestDTO request)
        {
            var toDoTask = await _toDoTaskService.Detail(request);

            return Ok(toDoTask);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<CreateToDoTaskResponseDTO>> Create([FromBody] CreateToDoTaskRequestDTO request)
        {
            var newTasks = await _toDoTaskService.Create(request);

            return Ok(newTasks);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<UpdateToDoTaskResponseDTO>> Update([FromBody] UpdateToDoTaskRequestDTO request)
        {
            var toDoTask = await _toDoTaskService.Update(request);

            return Ok(toDoTask);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<DeleteToDoTaskResponseDTO>> Delete([FromBody] GetToDoTaskIdRequestDTO request)
        {
           var response = await _toDoTaskService.Delete(request);

            return Ok(response);
        }
    }
}
