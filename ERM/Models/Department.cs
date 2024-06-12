using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERM.Models
{
    [Table("Department")]
    public class Department
    {
        [Required]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set;}
        public string DepartmentPhone { get; set;}
        public string DepartmentEmail { get; set;}

        public List<Manager> DepartmentManagers { get; set; }
        public List<Employee> DepartmentEmployees { get; set; }
    }
}
