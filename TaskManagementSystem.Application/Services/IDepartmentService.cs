using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;

namespace TaskManagementSystem.Application.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> GetDepartmentByIdAsync(int id);
        Task<List<DepartmentDTO>> GetAllDepartmentAsync();
        Task<DepartmentDTO> AddDepartmentAsync(DepartmentDTO departmentDto);
        Task<Department> UpdateDepartmentAsync(DepartmentDTO departmentDto, int id);
        Task DeleteDepartmentAsync(int id);
    }
}
