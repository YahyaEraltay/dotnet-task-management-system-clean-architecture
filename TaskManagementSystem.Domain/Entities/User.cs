using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        //Many to One
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        //One to Many
        public List<ToDoTask> ToDoTasks { get; set; }
    }
}
