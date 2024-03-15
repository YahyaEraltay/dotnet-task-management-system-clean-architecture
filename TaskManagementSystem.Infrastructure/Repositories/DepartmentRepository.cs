using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
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

        public async Task<Department> Create(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return department;
        }

        public async Task<Department> Delete(Department department)
        {
            var deletedDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Id == department.Id);

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return deletedDepartment;
        }

        public async Task<List<Department>> All()
        {
            var departments = await _context.Departments.ToListAsync();

            if (departments != null)
            {
                return departments;
            }
            else
            {
                throw new Exception("There is no department");
            }
        }

        public async Task<Department> Detail(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);

            return department;
        }

        public async Task<Department> Update(UpdateDepartmentRequestDTO request)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == request.Id);

            department.DepartmentName = request.DepartmentName;

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

            return department;
        }
    }
}
