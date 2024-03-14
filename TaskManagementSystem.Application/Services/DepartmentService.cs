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

        public async Task<DepartmentResponseDTO> Create(DepartmentRequestDTO request)
        {
            var department = new Department
            {
                DepartmentName = request.DepartmentName
            };

            await _departmentRepository.Create(department);

            return new DepartmentResponseDTO
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }

        public async Task Delete(DeleteDepartmentRequestDTO request)
        {
            await _departmentRepository.Delete(request.Id);
        }

        public async Task<List<DepartmentResponseDTO>> All()
        {
            var departments = await _departmentRepository.All();

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

        public async Task<GetDepartmentByIdResponseDTO> Detail(GetDepartmentByIdRequestDTO request)
        {
            var department = await _departmentRepository.Detail(request.Id);

            return new GetDepartmentByIdResponseDTO
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }

        public async Task<UpdateDepartmentResponseDTO> Update(UpdateDepartmentRequestDTO request)
        {
            var department = await _departmentRepository.Detail(request.Id);

            department.DepartmentName = request.DepartmentName;

            await _departmentRepository.Update(request);

            return new UpdateDepartmentResponseDTO()
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }
    }
}
