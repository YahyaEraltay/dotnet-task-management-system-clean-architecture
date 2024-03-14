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
        Task<GetToDoTaskResponseDTO> Detail(GetToDoTaskIdRequestDTO request);
        Task<CreateToDoTaskResponseDTO> Create(CreateToDoTaskRequestDTO request);
        Task<UpdateToDoTaskResponseDTO> Update(UpdateToDoTaskRequestDTO request);
        Task Delete(GetToDoTaskIdRequestDTO request);
        Task<List<GetToDoTaskResponseDTO>> All();
    }
}
