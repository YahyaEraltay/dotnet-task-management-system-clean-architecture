using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTO;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<List<Department>> GetAllDepartmentAsync();
        Task<Department> AddDepartmentAsync(DepartmentDTO departmentDto);
        Task<Department> UpdateDepartmentAsync(DepartmentDTO departmentDto, int id);
        Task DeleteDepartmentAsync(int id);
    }
}
