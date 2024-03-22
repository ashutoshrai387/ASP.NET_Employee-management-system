using Employee_Management_System.Data;
using Employee_Management_System.Dtos;
using Employee_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeDto> AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                DepartmentId = employeeDto.DepartmentId,
                Salary = employeeDto.Salary
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            employeeDto.Id = employee.Id;
            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await _context.Employees
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    DepartmentId = e.DepartmentId,
                    Salary = e.Salary
                })
                .ToListAsync();

            return employees;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return null;
            }

            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                DepartmentId = employee.DepartmentId,
                Salary = employee.Salary
            };
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            employee.Name = employeeDto.Name;
            employee.Age = employeeDto.Age;
            employee.DepartmentId = employeeDto.DepartmentId;
            employee.Salary = employeeDto.Salary;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
