using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERM.Models
{
    [Table("EmployeeClockInClockOut")]
    public class EmployeeClockInClockOut
    {
        [Required]
        [Key]
        public int ClockRecordId { get; set; }
        public int EmployeeId { get; set; } 
        public string UserId { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime ClockInTime { get; set; }
        public bool ClockedIn { get; set; }
        public DateTime ClockOutTime { get; set; }
        public bool ClockedOut { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
