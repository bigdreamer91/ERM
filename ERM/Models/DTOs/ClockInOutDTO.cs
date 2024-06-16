using System.ComponentModel.DataAnnotations;

namespace ERM.Models.DTOs
{
    public class ClockInOutDTO
    {
        public string EmployeeName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CurrentDate { get; set; }
        public EmployeeClockInClockOut EmployeeClockInClockOut { get; set; }
    }
}
