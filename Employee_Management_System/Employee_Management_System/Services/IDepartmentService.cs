using Employee_Management_System.Dtos;

namespace Employee_Management_System.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentDto> AddDepartmentAsync(DepartmentDto departmentDto);
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
        Task UpdateDepartmentAsync(int id, DepartmentDto departmentDto);
        Task DeleteDepartmentAsync(int id);
    }
}
