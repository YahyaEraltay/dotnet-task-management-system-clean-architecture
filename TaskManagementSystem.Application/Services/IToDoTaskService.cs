using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel;

namespace TaskManagementSystem.Application.Services
{
    public interface IToDoTaskService
    {
        Task<ToDoTaskDTO> GetToDoTaskByIdAsync(int id);
        Task<ToDoTaskResponseDTO> AddToDoTaskAsync(ToDoTaskRequestDTO request);
        Task<ToDoTask> UpdateToDoTaskAsync(ToDoTaskDTO toDoTaskDto, int id);
        Task DeleteToDoTaskAsync(DeleteToDoTaskRequestDTO request);
        Task<List<TaskDTO>> GetAllToDoTaskAync();
    }
}
