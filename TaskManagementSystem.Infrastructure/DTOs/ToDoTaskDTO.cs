﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs
{
    public class ToDoTaskDTO
    {
        public string ToDoTaskName { get; set; }
        public int DepartmentId { get; set; }
        public int CreaterUserId { get; set; }
    }
}
