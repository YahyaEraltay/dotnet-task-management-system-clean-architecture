using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentResponseDTO> AddDepartmentAsync(DepartmentRequestDTO request)
        {
            var department = new Department
            {
                DepartmentName = request.DepartmentName
            };

            await _departmentRepository.AddDepartmentAsync(department);

            return new DepartmentResponseDTO
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }

        public async Task DeleteDepartmentAsync(DeleteDepartmentRequestDTO request)
        {
            await _departmentRepository.DeleteDepartmentAsync(request.Id);
        }

        public async Task<List<DepartmentResponseDTO>> GetAllDepartmentAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentAsync();

            var response = new List<DepartmentResponseDTO>();

            foreach (var department in departments)
            {
                response.Add(new DepartmentResponseDTO()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName
                });

            }
            return response;
        }

        public async Task<GetDepartmentByIdResponseDTO> GetDepartmentByIdAsync(GetDepartmentByIdRequestDTO request)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(request.Id);

            return new GetDepartmentByIdResponseDTO
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }

        public async Task<UpdateDepartmentResponseDTO> UpdateDepartmentAsync(UpdateDepartmentRequestDTO request)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(request.Id);

            department.DepartmentName = request.DepartmentName;

            await _departmentRepository.UpdateDepartmentAsync(request);

            return new UpdateDepartmentResponseDTO()
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }
    }
}
