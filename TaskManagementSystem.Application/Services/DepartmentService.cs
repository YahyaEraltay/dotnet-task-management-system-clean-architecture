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

        public async Task<CreateDepartmentResponseDTO> Create(CreateDepartmentRequestDTO request)
        {
            var department = new Department
            {
                DepartmentName = request.DepartmentName
            };

            await _departmentRepository.Create(department);

            return new CreateDepartmentResponseDTO
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }

        public async Task<DeleteDepartmentResponseDTO> Delete(GetDepartmentIdRequestDTO request)
        {
            var department = await _departmentRepository.Detail(request.Id);
            var response = new DeleteDepartmentResponseDTO();

            if (department != null)
            {
                await _departmentRepository.Delete(department);
                response.IsDeleted = true;
                response.Message = "Department deleted";
            }
            else
            {
                response.IsDeleted = false;
                response.Message = "Department could not be deleted";
            }
            return response;
        }

        public async Task<List<GetDepartmentResponseDTO>> All()
        {
            var departments = await _departmentRepository.All();

            var response = new List<GetDepartmentResponseDTO>();

            foreach (var department in departments)
            {
                response.Add(new GetDepartmentResponseDTO()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName
                });

            }
            return response;
        }

        public async Task<GetDepartmentResponseDTO> Detail(GetDepartmentIdRequestDTO request)
        {
            var department = await _departmentRepository.Detail(request.Id);

            if (department != null)
            {
                return new GetDepartmentResponseDTO
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName
                };
            }
            else
            {
                throw new Exception("Department could not be found");
            }

        }

        public async Task<UpdateDepartmentResponseDTO> Update(UpdateDepartmentRequestDTO request)
        {
            var department = await _departmentRepository.Detail(request.Id);

            if (department != null)
            {
                department.DepartmentName = request.DepartmentName;
                await _departmentRepository.Update(request);

                return new UpdateDepartmentResponseDTO()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName
                };
            }
            else
            {
                throw new Exception("Department Not Found");
            }
        }
    }
}
