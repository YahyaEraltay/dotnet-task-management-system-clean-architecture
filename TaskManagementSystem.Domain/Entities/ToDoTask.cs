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
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
        public ToDoTaskStatus Status { get; set; }

        public enum ToDoTaskStatus
        {
            Pending = 0,
            Completed = 1,
            Denied = 2
        }
    }
}

