using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs.UserDTOs
{
    public class GetUserDTO
    {
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string DepartmentName { get; set; }
    }
}
