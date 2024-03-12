using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.Application.Services
{
    public interface IDepartmentService
    {
        Task<GetDepartmentByIdResponseDTO> GetDepartmentByIdAsync(GetDepartmentByIdRequestDTO request);
        Task<List<DepartmentResponseDTO>> GetAllDepartmentAsync();
        Task<DepartmentResponseDTO> AddDepartmentAsync(DepartmentRequestDTO request);
        Task<UpdateDepartmentResponseDTO> UpdateDepartmentAsync(UpdateDepartmentRequestDTO request);
        Task DeleteDepartmentAsync(DeleteDepartmentRequestDTO request);
    }
}
