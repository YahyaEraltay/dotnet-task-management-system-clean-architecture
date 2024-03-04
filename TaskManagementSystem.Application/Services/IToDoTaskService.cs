﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;

namespace TaskManagementSystem.Application.Services
{
    public interface IToDoTaskService
    {
        Task<ToDoTaskDTO> GetToDoTaskByIdAsync(int id);
        //Task<List<ToDoTaskDTO>> GetAllToDoTaskAsync();
        Task<ToDoTaskDTO> AddToDoTaskAsync(ToDoTaskDTO toDoTaskDto);
        Task<ToDoTask> UpdateToDoTaskAsync(ToDoTaskDTO toDoTaskDto, int id);
        Task DeleteToDoTaskAsync(int id);
        Task<List<TaskDTO>> GetAllToDoTaskAync();
    }
}
