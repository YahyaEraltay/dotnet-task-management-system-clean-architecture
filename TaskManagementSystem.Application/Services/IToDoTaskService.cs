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
        Task<GetToDoTaskByIdResponseDTO> GetToDoTaskByIdAsync(GetToDoTaskByIdRequestDTO request);
        Task<ToDoTaskResponseDTO> AddToDoTaskAsync(ToDoTaskRequestDTO request);
        Task<UpdateToDoTaskResponseDTO> UpdateToDoTaskAsync(UpdateToDoTaskRequestDTO request);
        Task DeleteToDoTaskAsync(DeleteToDoTaskRequestDTO request);
        Task<List<GetAllToDoTaskResponseDTO>> GetAllToDoTaskAync();
    }
}
