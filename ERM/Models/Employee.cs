using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERM.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int UserId { get; set; }
        public string EmployeeDesignation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
