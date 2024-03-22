using AutoMapper;
using Employee_Management_System.Dtos;
using Employee_Management_System.Models;

namespace Employee_Management_System.ObjectMapping
{
    public class AppAutoMapperProfile : Profile
    {
        public AppAutoMapperProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
