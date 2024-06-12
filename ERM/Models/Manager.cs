using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERM.Models
{
    [Table("Manager")]
    public class Manager
    {
        [Required]
        public int ManagerId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string ManagerRole { get; set; }
        public List<Employee> Employees { get; set;}
        public int IsActive { get; set; }
    }
}
