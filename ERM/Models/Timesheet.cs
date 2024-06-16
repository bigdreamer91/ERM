using ERM.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERM.Models
{
    [Table("Timesheet")]
    public class Timesheet
    {
        [Required]
        [Key]
        public int TimesheetRecordId { get; set; }
        public int EmployeeId { get; set; }
        public List<EmployeeClockInClockOut> ClockInClockOuts { get; set; }    
        public TimesheetStatus Status { get; set; }
        public bool IsActive { get; set; } 
        public int AuthorizedById { get; set; }
        public string AuthorizedByName { get; set;}
    }
}
