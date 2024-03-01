using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;
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

        public async Task<DepartmentDTO> AddDepartmentAsync(DepartmentDTO departmentDto)
        {
            await _departmentRepository.AddDepartmentAsync(departmentDto);
            return departmentDto;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
        }

        public async Task<List<DepartmentDTO>> GetAllDepartmentAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentAsync();
            var response = new List<DepartmentDTO> { };
            foreach (var department in departments)
            {
                response.Add(new DepartmentDTO()
                {
                    DepartmentName = department.DepartmentName
                });

            }
            return response;
        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            return new DepartmentDTO
            {
                DepartmentName = department.DepartmentName
            };
        }

        public async Task<Department> UpdateDepartmentAsync(DepartmentDTO departmentDto, int id)
        {
            return await _departmentRepository.UpdateDepartmentAsync(departmentDto, id);
        }
    }
}
