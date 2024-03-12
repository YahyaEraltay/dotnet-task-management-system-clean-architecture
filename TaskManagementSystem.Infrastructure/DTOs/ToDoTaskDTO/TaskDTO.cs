using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string DepartmentName { get; set; }
        public List<AssignedTaskDTO> AssignedTasks { get; set; }
    }
}
    