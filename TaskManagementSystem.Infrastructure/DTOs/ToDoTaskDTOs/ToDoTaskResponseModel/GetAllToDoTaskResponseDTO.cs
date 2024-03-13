using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel
{
    public class GetAllToDoTaskResponseDTO
    {
        public int Id { get; set; }
        public string ToDoTaskName { get; set; }
        public string AssignedUserName { get; set; }
        public string AssignedUserEmail { get; set; }
        public string CreaterUserName { get; set; }
        public string DepartmentName { get; set; }
    }
}
