using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs;
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
            _context.ToDoTask.Add(toDoTask);
            await _context.SaveChangesAsync();

            return toDoTask;
        }

        public async Task DeleteToDoTaskAsync(int id)
        {
            var toDoTask = await _context.ToDoTask.FirstOrDefaultAsync(x => x.Id == id);

            if (toDoTask == null)
            {
                throw new Exception("Id not found");
            }

            _context.ToDoTask.Remove(toDoTask);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ToDoTask>> GetAllToDoTaskAsync()
        {
            return await _context.ToDoTask.ToListAsync();
        }

        public async Task<ToDoTask> GetToDoTaskByIdAsync(int id)
        {
            var toDoTask = await _context.ToDoTask.FirstOrDefaultAsync(x => x.Id == id);

            if (toDoTask == null) 
            {
                throw new Exception("To do task not found"); 
            }

            return toDoTask;
        }

        public async Task<ToDoTask> UpdateToDoTaskAsync(ToDoTaskDTO toDoTaskDto, int id)
        {
            var toDoTask = await _context.ToDoTask.FirstOrDefaultAsync(x => x.Id == id);

            if (toDoTask == null)
            {
                throw new Exception("Id not found");
            }

            toDoTask.ToDoTaskName = toDoTaskDto.ToDoTaskName;
            toDoTask.DepartmentId = toDoTaskDto.DepartmentId;
            toDoTask.CreaterUserId = toDoTaskDto.CreaterUserId;
            toDoTask.AssignedUserId = toDoTaskDto.AssignedUserId;

            _context.ToDoTask.Update(toDoTask);
            await _context.SaveChangesAsync();

            return toDoTask;
        }
    }
}
