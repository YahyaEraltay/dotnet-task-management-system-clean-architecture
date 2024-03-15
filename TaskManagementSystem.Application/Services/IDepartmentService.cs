using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.Application.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentResponseDTO> Detail(GetDepartmentIdRequestDTO request);
        Task<List<DepartmentResponseDTO>> All();
        Task<DepartmentResponseDTO> Create(CreateDepartmentRequestDTO request);
        Task<DepartmentResponseDTO> Update(UpdateDepartmentRequestDTO request);
        Task<DeleteDepartmentResponseDTO> Delete(GetDepartmentIdRequestDTO request);
    }
}
