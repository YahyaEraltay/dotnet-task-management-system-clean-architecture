using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
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

        public async Task<ToDoTask> Create(ToDoTask toDoTask)
        {
            _context.ToDoTask.Add(toDoTask);
            await _context.SaveChangesAsync();

            return toDoTask;
        }

        public async Task Delete(int id)
        {
            var toDoTask = await _context.ToDoTask.FirstOrDefaultAsync(x => x.Id == id);

            if (toDoTask == null)
            {
                throw new Exception("Id not found");
            }

            _context.ToDoTask.Remove(toDoTask);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ToDoTask>> All()
        {
            return await _context.ToDoTask
                                   .Include(t => t.AssignedUser)
                                   .Include(t => t.CreaterUser)
                                   .Include(t => t.Department)
                                   .ToListAsync();
        }

        public async Task<ToDoTask> Detail(int id)
        {
            var toDoTask = await _context.ToDoTask.FirstOrDefaultAsync(x => x.Id == id);

            if (toDoTask == null)
            {
                throw new Exception("To do task not found");
            }

            return toDoTask;
        }

        public async Task<ToDoTask> Update(UpdateToDoTaskRequestDTO request)
        {
            var toDoTask = await _context.ToDoTask.FindAsync(request.Id);

            if (toDoTask == null)
            {
                throw new Exception("Id not found");
            }

            toDoTask.ToDoTaskName = request.ToDoTaskName;
            toDoTask.DepartmentId = request.DepartmentId;
            toDoTask.CreaterUserId = request.CreaterUserId;
            toDoTask.AssignedUserId = request.AssignedUserId;

            _context.ToDoTask.Update(toDoTask);
            await _context.SaveChangesAsync();

            return toDoTask;
        }
    }
}
