using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task<ToDoTask> AddToDoTaskAsync(ToDoTaskDTO toDoTaskDto)
        {
            return await _toDoTaskRepository.AddToDoTaskAsync(toDoTaskDto);
        }

        public async Task DeleteToDoTaskAsync(int id)
        {
            await _toDoTaskRepository.DeleteToDoTaskAsync(id);
        }

        public async Task<List<ToDoTask>> GetAllToDoTaskAsync()
        {
            return await _toDoTaskRepository.GetAllToDoTaskAsync();
        }

        public async Task<ToDoTask> GetToDoTaskByIdAsync(int id)
        {
            return await _toDoTaskRepository.GetToDoTaskByIdAsync(id);
        }

        public async Task<ToDoTask> UpdateToDoTaskAsync(ToDoTaskDTO toDoTaskDto, int id)
        {
            return await _toDoTaskRepository.UpdateToDoTaskAsync(toDoTaskDto, id);
        }
    }
}
