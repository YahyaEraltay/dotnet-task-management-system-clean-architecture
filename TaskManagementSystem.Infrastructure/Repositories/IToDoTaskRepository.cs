using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface IToDoTaskRepository
    {
        Task<ToDoTask> Detail(int id);
        Task<ToDoTask> Create(ToDoTask toDoTask);
        Task<ToDoTask> Update(UpdateToDoTaskRequestDTO request);
        Task Delete(int id);
        Task<List<ToDoTask>> All();
    }
}
