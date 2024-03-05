using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository, IDepartmentRepository departmentRepository, IUserRepository userRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
        }

        public async Task<ToDoTaskDTO> AddToDoTaskAsync(ToDoTaskDTO toDoTaskDto)
        {
            await _toDoTaskRepository.AddToDoTaskAsync(toDoTaskDto);
            return toDoTaskDto;
        }

        public async Task DeleteToDoTaskAsync(int id)
        {
            await _toDoTaskRepository.DeleteToDoTaskAsync(id);
        }

        public async Task<List<TaskDTO>> GetAllToDoTaskAync()
        {
            var tasks = await _toDoTaskRepository.GetAllToDoTaskAsync();
            var taskDTOs = new List<TaskDTO>();

            foreach (var task in tasks)
            {
                var user = await _userRepository.GetUserByIdAsync(task.AssignedUserId);
                var department = await _departmentRepository.GetDepartmentByIdAsync(task.DepartmentId);

                var taskDTO = new TaskDTO
                {
                    UserName = user.UserName,
                    Mail = user.Mail,
                    DepartmentName = department.DepartmentName,
                    AssignedTasks = new List<AssignedTaskDTO>()
                };

                if (task.AssignedUserId != null)
                {
                    var creatorUser = await _userRepository.GetUserByIdAsync(task.CreaterUserId);
                    taskDTO.AssignedTasks.Add(new AssignedTaskDTO
                    {
                        ToDoTaskName = task.ToDoTaskName,
                        CreaterUserName = creatorUser.UserName,
                    });
                }

                taskDTOs.Add(taskDTO);
            }

            return taskDTOs;
        }

        public async Task<ToDoTaskDTO> GetToDoTaskByIdAsync(int id)
        {
            var toDoTask = await _toDoTaskRepository.GetToDoTaskByIdAsync(id);
            var toDoTaskDTO = new ToDoTaskDTO()
            {
                ToDoTaskName = toDoTask.ToDoTaskName,
                DepartmentId = toDoTask.DepartmentId,
                CreaterUserId = toDoTask.CreaterUserId,
            };
            return toDoTaskDTO;
        }

        public async Task<ToDoTask> UpdateToDoTaskAsync(ToDoTaskDTO toDoTaskDto, int id)
        {
            return await _toDoTaskRepository.UpdateToDoTaskAsync(toDoTaskDto, id);
        }
    }
}
