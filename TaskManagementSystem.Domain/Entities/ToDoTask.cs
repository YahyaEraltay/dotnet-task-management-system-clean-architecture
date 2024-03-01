using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string ToDoTaskName { get; set; }

        //Many To One
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public User CreaterUser { get; set; }
        public int CreaterUserId { get; set; }
    }
}

