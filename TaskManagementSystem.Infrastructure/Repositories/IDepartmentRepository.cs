using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> Detail(int id);
        Task<List<Department>> All();
        Task<Department> Create(Department department);
        Task<Department> Update(UpdateDepartmentRequestDTO request);
        Task Delete(int id);
    }
}
