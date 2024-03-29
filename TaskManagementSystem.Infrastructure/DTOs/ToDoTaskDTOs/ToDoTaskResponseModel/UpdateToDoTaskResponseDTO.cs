﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagementSystem.Domain.Entities.ToDoTask;

namespace TaskManagementSystem.Infrastructure.DTOs.ToDoTaskDTOs.ToDoTaskResponseModel
{
    public class UpdateToDoTaskResponseDTO
    {
        public int Id { get; set; }
        public string ToDoTaskName { get; set; }
        public string DepartmentName { get; set; }
        public string CreaterUserName { get; set; }
        public string AssignedUserName { get; set; }
        public ToDoTaskStatus Status { get; set; }
    }
}
