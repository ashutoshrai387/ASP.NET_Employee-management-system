using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Dtos
{
    public class EmployeeDto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int DepartmentId { get; set; }

        public decimal Salary { get; set; }
    }
}
