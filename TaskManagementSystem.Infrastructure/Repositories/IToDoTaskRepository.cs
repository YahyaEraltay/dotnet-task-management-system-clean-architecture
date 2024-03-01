using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface IToDoTaskRepository
    {
        Task<ToDoTask> GetToDoTaskByIdAsync(int id);
        Task<List<ToDoTask>> GetAllToDoTaskAsync();
        Task<ToDoTask> AddToDoTaskAsync(ToDoTaskDTO toDoTaskDto);
        Task<ToDoTask> UpdateToDoTaskAsync(ToDoTaskDTO toDoTaskDto, int id);
        Task DeleteToDoTaskAsync(int id);
    }
}
