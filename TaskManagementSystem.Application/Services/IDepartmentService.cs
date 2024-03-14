using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;

namespace TaskManagementSystem.Application.Services
{
    public interface IDepartmentService
    {
        Task<GetDepartmentByIdResponseDTO> Detail(GetDepartmentByIdRequestDTO request);
        Task<List<DepartmentResponseDTO>> All();
        Task<DepartmentResponseDTO> Create(DepartmentRequestDTO request);
        Task<UpdateDepartmentResponseDTO> Update(UpdateDepartmentRequestDTO request);
        Task Delete(DeleteDepartmentRequestDTO request);
    }
}
