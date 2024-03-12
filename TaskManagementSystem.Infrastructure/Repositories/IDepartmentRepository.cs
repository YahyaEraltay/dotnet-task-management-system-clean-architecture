using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<List<Department>> GetAllDepartmentAsync();
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(UpdateDepartmentRequestDTO request);
        Task DeleteDepartmentAsync(int id);
    }
}
