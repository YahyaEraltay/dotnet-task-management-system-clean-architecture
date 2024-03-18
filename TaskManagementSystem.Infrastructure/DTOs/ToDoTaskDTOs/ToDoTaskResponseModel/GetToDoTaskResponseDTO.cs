using static TaskManagementSystem.Domain.Entities.ToDoTask;

namespace TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel
{
    public class GetToDoTaskResponseDTO
    {
        public int Id { get; set; }
        public string AssignedUserName { get; set; }
        public string AssignedUserEmail { get; set; }
        public string DepartmentName { get; set; }
        public string ToDoTaskName { get; set; }
        public string CreaterUserName { get; set; }
        public ToDoTaskStatus Status { get; set; }
    }
}
