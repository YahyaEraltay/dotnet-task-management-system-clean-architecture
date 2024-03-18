using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagementSystem.Domain.Entities.ToDoTask;

namespace TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskRequestModel
{
    public class CreateToDoTaskRequestDTO
    {
        public string ToDoTaskName { get; set; }
        public int DepartmentId { get; set; }
        public int CreaterUserId { get; set; }
        public int AssignedUserId { get; set; }
        public ToDoTaskStatus Status { get; set; }
    }
}
