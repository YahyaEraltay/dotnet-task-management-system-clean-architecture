﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel
{
    public class UpdateDepartmentRequestDTO
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
