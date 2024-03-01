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

        public async Task<Department> AddDepartmentAsync(DepartmentDTO departmentDto)
        {
            return await _departmentRepository.AddDepartmentAsync(departmentDto);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
        }

        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            return await _departmentRepository.GetAllDepartmentAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public async Task<Department> UpdateDepartmentAsync(DepartmentDTO departmentDto, int id)
        {
            return await _departmentRepository.UpdateDepartmentAsync(departmentDto, id);
        }
    }
}
