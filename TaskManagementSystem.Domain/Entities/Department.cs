using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        //One to Many
        public List<User> Users { get; set; }
        public List<ToDoTask> ToDoTasks { get; set; }
    }
}
