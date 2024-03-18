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

        public async Task<ToDoTask> Delete(ToDoTask toDoTask)
        {
            var deletedToDoTask = await _context.ToDoTask.FirstOrDefaultAsync(x => x.Id == toDoTask.Id);

            _context.ToDoTask.Remove(toDoTask);
            await _context.SaveChangesAsync();

            return deletedToDoTask;
        }

        public async Task<List<ToDoTask>> All()
        {
            var toDoTasks = await _context.ToDoTask
                                   .Include(t => t.AssignedUser)
                                   .Include(t => t.CreaterUser)
                                   .Include(t => t.Department)
                                   .ToListAsync();
            if (toDoTasks != null)
            {
                return toDoTasks;
            }
            else
            {
                throw new Exception("There is no task");
            }
        }

        public async Task<ToDoTask> Detail(int id)
        {
            var toDoTask = await _context.ToDoTask
                                         .Include(x => x.AssignedUser)
                                         .Include(x => x.CreaterUser)
                                         .Include(x => x.Department)
                                         .FirstOrDefaultAsync(x => x.Id == id);

            return toDoTask;
        }

        public async Task<ToDoTask> Update(UpdateToDoTaskRequestDTO request)
        {
            var toDoTask = await _context.ToDoTask
                                         .Include(x => x.AssignedUser)
                                         .Include(x => x.CreaterUser)
                                         .Include(x => x.Department)
                                         .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (toDoTask == null)
            {
                throw new Exception("Id not found");
            }

            toDoTask.ToDoTaskName = request.ToDoTaskName;
            toDoTask.DepartmentId = request.DepartmentId;
            toDoTask.CreaterUserId = request.CreaterUserId;
            toDoTask.AssignedUserId = request.AssignedUserId;
            toDoTask.Status = request.Status;

            _context.ToDoTask.Update(toDoTask);
            await _context.SaveChangesAsync();

            return toDoTask;
        }
    }
}
