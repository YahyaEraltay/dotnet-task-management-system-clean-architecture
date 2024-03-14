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

        public async Task<CreateToDoTaskResponseDTO> Create(CreateToDoTaskRequestDTO request)
        {
            var toDoTask = new ToDoTask()
            {
                ToDoTaskName = request.ToDoTaskName,
                DepartmentId = request.DepartmentId,
                CreaterUserId = request.CreaterUserId,
                AssignedUserId = request.AssignedUserId,
            };

            await _toDoTaskRepository.Create(toDoTask);

            return new CreateToDoTaskResponseDTO
            {
                Id = toDoTask.Id,
                ToDoTaskName = toDoTask.ToDoTaskName,
                DepartmentId = toDoTask.DepartmentId,
                CreaterUserId = toDoTask.CreaterUserId,
                AssignedUserId = toDoTask.AssignedUserId,
            };
        }

        public async Task Delete(GetToDoTaskIdRequestDTO request)
        {
            await _toDoTaskRepository.Delete(request.Id);
        }

        public async Task<List<GetToDoTaskResponseDTO>> All()
        {
            var tasks = await _toDoTaskRepository.All();
            var taskDTOs = new List<GetToDoTaskResponseDTO>();

            foreach (var task in tasks)
            {

                var taskDTO = new GetToDoTaskResponseDTO
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

        public async Task<GetToDoTaskResponseDTO> Detail(GetToDoTaskIdRequestDTO request)
        {
            var toDoTask = await _toDoTaskRepository.Detail(request.Id);
            var department = await _departmentRepository.Detail(toDoTask.DepartmentId);
            var creatorUser = await _userRepository.Detail(toDoTask.CreaterUserId);
            var assignedUser = await _userRepository.Detail(toDoTask.AssignedUserId);

            var toDoTaskDTO = new GetToDoTaskResponseDTO()
            {
                Id = toDoTask.Id,
                ToDoTaskName = toDoTask.ToDoTaskName,
                DepartmentName = department.DepartmentName,
                CreaterUserName = creatorUser.UserName,
                AssignedUserName = assignedUser.UserName,
                AssignedUserEmail = assignedUser.Mail
            };

            return toDoTaskDTO;
        }

        public async Task<UpdateToDoTaskResponseDTO> Update(UpdateToDoTaskRequestDTO request)
        {
            var toDoTask = await _toDoTaskRepository.Detail(request.Id);
            var department = await _departmentRepository.Detail(request.DepartmentId);
            var creatorUser = await _userRepository.Detail(request.CreaterUserId);
            var assignedUser = await _userRepository.Detail(request.AssignedUserId);


            toDoTask.ToDoTaskName = request.ToDoTaskName;
            toDoTask.DepartmentId = request.DepartmentId;
            toDoTask.CreaterUserId = request.CreaterUserId;
            toDoTask.AssignedUserId = request.AssignedUserId;

            await _toDoTaskRepository.Update(request);

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
