using Employee_Management_System.Data;
using Employee_Management_System.Dtos;
using Employee_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DepartmentDto> AddDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = new Department
            {
                Id = departmentDto.Id,
                DepartmentName = departmentDto.DepartmentName
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            departmentDto.Id = department.Id;
            return departmentDto;
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
        {
            var departments = await _context.Departments
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    DepartmentName = d.DepartmentName
                })
                .ToListAsync();

            return departments;
        }

        public async Task UpdateDepartmentAsync(int id, DepartmentDto departmentDto)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                throw new Exception("Department not found.");
            }

            department.DepartmentName = departmentDto.DepartmentName;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                throw new Exception("Department not found.");
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}
