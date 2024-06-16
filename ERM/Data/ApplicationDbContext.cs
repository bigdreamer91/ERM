using ERM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeClockInClockOut> EmployeeClockInClockOuts { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<ClockInOutLog> ClockInOutLogs { get; set; }
    }
}
