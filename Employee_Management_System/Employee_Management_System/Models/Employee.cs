using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.Models
{
    public class Employee
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Range(21, 100)]
        public int Age { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
