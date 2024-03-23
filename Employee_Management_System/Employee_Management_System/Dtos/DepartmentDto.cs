using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Dtos
{
    public class DepartmentDto
    {
        [Key]
        public int Id { get; set; }

        public string DepartmentName { get; set; }
    }
}
