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

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
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

        public async Task<DeleteToDoTaskResponseDTO> Delete(GetToDoTaskIdRequestDTO request)
        {
            var toDoTask = await _toDoTaskRepository.Detail(request.Id);
            var response = new DeleteToDoTaskResponseDTO();

            if (toDoTask != null)
            {
                await _toDoTaskRepository.Delete(toDoTask);
                response.IsDeleted = true;
                response.Message = "Task deleted";
            }
            else
            {
                response.IsDeleted = false;
                response.Message = "Task could not be deleted";
            }

            return response;
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
                    ToDoTaskName = task.ToDoTaskName,
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

            if (toDoTask != null)
            {
                var toDoTaskDTO = new GetToDoTaskResponseDTO()
                {
                    Id = toDoTask.Id,
                    ToDoTaskName = toDoTask.ToDoTaskName,
                    DepartmentName = toDoTask.Department.DepartmentName,
                    CreaterUserName = toDoTask.CreaterUser.UserName,
                    AssignedUserName = toDoTask.AssignedUser.UserName,
                    AssignedUserEmail = toDoTask.AssignedUser.Mail
                };

                return toDoTaskDTO;
            }
            else
            {
                throw new Exception("Task not found");
            }
        }

        public async Task<UpdateToDoTaskResponseDTO> Update(UpdateToDoTaskRequestDTO request)
        {
            var toDoTask = await _toDoTaskRepository.Detail(request.Id);

            if (toDoTask != null)
            {
                toDoTask.ToDoTaskName = request.ToDoTaskName;
                toDoTask.DepartmentId = request.DepartmentId;
                toDoTask.CreaterUserId = request.CreaterUserId;
                toDoTask.AssignedUserId = request.AssignedUserId;

                await _toDoTaskRepository.Update(request);

                return new UpdateToDoTaskResponseDTO
                {
                    Id = toDoTask.Id,
                    ToDoTaskName = toDoTask.ToDoTaskName,
                    DepartmentName = toDoTask.Department.DepartmentName,
                    CreaterUserName = toDoTask.CreaterUser.UserName,
                    AssignedUserName = toDoTask.AssignedUser.UserName,
                };
            }
            else
            {
                throw new Exception("Task not found");
            }
        }
    }
}
