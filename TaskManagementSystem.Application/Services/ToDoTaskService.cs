using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel;
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

        public async Task<ToDoTaskResponseDTO> AddToDoTaskAsync(ToDoTaskRequestDTO request)
        {
            var toDoTask = new ToDoTask()
            {
                ToDoTaskName = request.ToDoTaskName,
                DepartmentId = request.DepartmentId,
                CreaterUserId = request.CreaterUserId,
                AssignedUserId = request.AssignedUserId,
            };

            await _toDoTaskRepository.AddToDoTaskAsync(toDoTask);

            return new ToDoTaskResponseDTO
            {
                Id = toDoTask.Id,
                ToDoTaskName = toDoTask.ToDoTaskName,
                DepartmentId = toDoTask.DepartmentId,
                CreaterUserId = toDoTask.CreaterUserId,
                AssignedUserId = toDoTask.AssignedUserId,
            };
        }

        public async Task DeleteToDoTaskAsync(DeleteToDoTaskRequestDTO request)
        {
            await _toDoTaskRepository.DeleteToDoTaskAsync(request.Id);
        }

        public async Task<List<GetAllToDoTaskResponseDTO>> GetAllToDoTaskAync()
        {
            var tasks = await _toDoTaskRepository.GetAllToDoTaskAsync();
            var taskDTOs = new List<GetAllToDoTaskResponseDTO>();

            foreach (var task in tasks)
            {

                var taskDTO = new GetAllToDoTaskResponseDTO
                {
                    Id = task.Id,
                    ToDoTaskName= task.ToDoTaskName,
                    CreaterUserName = task.CreaterUser.UserName,
                    AssignedUserName = task.AssignedUser.UserName,
                    AssignedUserEmail = task.AssignedUser.Mail,
                    DepartmentName = task.Department.DepartmentName,
                };

                taskDTOs.Add(taskDTO);
            }

            return taskDTOs;
        }

        public async Task<GetToDoTaskByIdResponseDTO> GetToDoTaskByIdAsync(GetToDoTaskByIdRequestDTO request)
        {
            var toDoTask = await _toDoTaskRepository.GetToDoTaskByIdAsync(request.Id);
            var department = await _departmentRepository.GetDepartmentByIdAsync(toDoTask.DepartmentId);
            var creatorUser = await _userRepository.GetUserByIdAsync(toDoTask.CreaterUserId);
            var assignedUser = await _userRepository.GetUserByIdAsync(toDoTask.AssignedUserId);

            var toDoTaskDTO = new GetToDoTaskByIdResponseDTO()
            {
                Id = toDoTask.Id,
                ToDoTaskName = toDoTask.ToDoTaskName,
                DepartmentName = department.DepartmentName,
                CreaterUserName = creatorUser.UserName,
                AssignedUserName = assignedUser.UserName
            };

            return toDoTaskDTO;
        }

        public async Task<UpdateToDoTaskResponseDTO> UpdateToDoTaskAsync(UpdateToDoTaskRequestDTO request)
        {
            var toDoTask = await _toDoTaskRepository.GetToDoTaskByIdAsync(request.Id);
            var department = await _departmentRepository.GetDepartmentByIdAsync(request.DepartmentId);
            var creatorUser = await _userRepository.GetUserByIdAsync(request.CreaterUserId);
            var assignedUser = await _userRepository.GetUserByIdAsync(request.AssignedUserId);


            toDoTask.ToDoTaskName = request.ToDoTaskName;
            toDoTask.DepartmentId = request.DepartmentId;
            toDoTask.CreaterUserId = request.CreaterUserId;
            toDoTask.AssignedUserId = request.AssignedUserId;

            await _toDoTaskRepository.UpdateToDoTaskAsync(request);

            return new UpdateToDoTaskResponseDTO
            {
                Id = toDoTask.Id,
                ToDoTaskName = toDoTask.ToDoTaskName,
                DepartmentName = department.DepartmentName,
                CreaterUserName = creatorUser.UserName,
                AssignedUserName = assignedUser.UserName,
            };
        }
    }
}
