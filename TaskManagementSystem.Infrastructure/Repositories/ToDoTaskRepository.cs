using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;
using TaskManagementSystem.Infrastructure.RelationalDb;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ToDoTask> AddToDoTaskAsync(ToDoTask toDoTask)
        {
            await _context.ToDoTask.AddAsync(toDoTask);
            await _context.SaveChangesAsync();
            return toDoTask;
        }

        public async Task<ToDoTask> AddToDoTaskAsync(ToDoTaskDTO toDoTaskDto)
        {
            var toDoTask = new ToDoTask
            {
                ToDoTaskName = toDoTaskDto.ToDoTaskName,
                DepartmentId = toDoTaskDto.DepartmentId,
                CreaterUserId = toDoTaskDto.CreaterUserId
            };
            await _context.AddAsync(toDoTask);
            await _context.SaveChangesAsync();
            return toDoTask;
        }

        public async Task DeleteToDoTaskAsync(int id)
        {
            var x = await _context.ToDoTask.FindAsync(id);
            if (x != null)
            {
                _context.ToDoTask.Remove(x);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Task with the specified ID could not be found.");
            }
        }

        public async Task<List<ToDoTask>> GetAllToDoTaskAsync()
        {
            return await _context.ToDoTask.ToListAsync();
        }

        public async Task<ToDoTask> GetToDoTaskByIdAsync(int id)
        {
            var toDoTask = await _context.ToDoTask.FindAsync(id);
            if (toDoTask == null)
            {
                throw new Exception("User Not Found");
            }
            return toDoTask;
        }

        public async Task<ToDoTask> UpdateToDoTaskAsync(ToDoTaskDTO toDoTaskDto, int id)
        {
            var toDoTask = await _context.ToDoTask.FindAsync(id);
            toDoTask.ToDoTaskName = toDoTaskDto.ToDoTaskName;
            toDoTask.DepartmentId = toDoTaskDto.DepartmentId;
            toDoTask.CreaterUserId = toDoTaskDto.CreaterUserId;
            _context.Update(toDoTask);
            await _context.SaveChangesAsync();
            return toDoTask;
        }
    }
}
