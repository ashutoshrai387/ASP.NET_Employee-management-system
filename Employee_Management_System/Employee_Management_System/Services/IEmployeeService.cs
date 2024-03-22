using Employee_Management_System.Dtos;

namespace Employee_Management_System.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> AddEmployeeAsync(EmployeeDto employeeDto);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(int id, EmployeeDto employeeDto);
        Task DeleteEmployeeAsync(int id);
    }
}
