using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.Application.Services
{
    public interface IDepartmentService
    {
        Task<GetDepartmentResponseDTO> Detail(GetDepartmentIdRequestDTO request);
        Task<List<GetDepartmentResponseDTO>> All();
        Task<CreateDepartmentResponseDTO> Create(CreateDepartmentRequestDTO request);
        Task<UpdateDepartmentResponseDTO> Update(UpdateDepartmentRequestDTO request);
        Task<DeleteDepartmentResponseDTO> Delete(GetDepartmentIdRequestDTO request);
    }
}
