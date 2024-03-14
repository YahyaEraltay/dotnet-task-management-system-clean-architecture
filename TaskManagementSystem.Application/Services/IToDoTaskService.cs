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
        Task<GetToDoTaskByIdResponseDTO> Detail(GetToDoTaskByIdRequestDTO request);
        Task<ToDoTaskResponseDTO> Create(ToDoTaskRequestDTO request);
        Task<UpdateToDoTaskResponseDTO> Update(UpdateToDoTaskRequestDTO request);
        Task Delete(DeleteToDoTaskRequestDTO request);
        Task<List<GetAllToDoTaskResponseDTO>> All();
    }
}
