using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs;
using TaskManagementSystem.Infrastructure.RelationalDb;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = new Department
            {
                DepartmentName = departmentDto.DepartmentName
            };
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var x = await _context.Departments.FindAsync(id);
            if (x != null)
            {
                _context.Departments.Remove(x);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Task with the specified ID could not be found.");
            }
        }

        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            var x = await _context.Departments.ToListAsync();
            if (x != null)
            {
                return x;
            }

            throw new Exception("There is no department");
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                throw new Exception("User Not Found");
            }
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(DepartmentDTO departmentDto, int id)
        {
            var department = await _context.Departments.FindAsync(id);
            department.DepartmentName = departmentDto.DepartmentName;
            _context.Update(department);
            await _context.SaveChangesAsync();
            return department;

        }
    }
}
