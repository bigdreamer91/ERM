using ERM.Data;
using ERM.Models;
using ERM.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ERM.Repositories
{
    public class ClockInOutRepository : IClockInOutRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        public ClockInOutRepository(ApplicationDbContext db, 
            IHttpContextAccessor httpContextAccessor, 
            UserManager<IdentityUser> userManager, 
            IUserRepository userRepository)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task AddEmployeeClockInOut(EmployeeClockInClockOut employeeClockInOut)
        {
            try
            {
                await _db.EmployeeClockInClockOuts.AddAsync(employeeClockInOut);
                await AddClockInOutLog(employeeClockInOut);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task AddClockInOutLog(EmployeeClockInClockOut employeeClockInOut)
        {
            ClockInOutLog clockInOutLog = new ClockInOutLog()
            {
                ClockRecordId = employeeClockInOut.ClockRecordId,
                EmployeeId = employeeClockInOut.EmployeeId,
                UserId = employeeClockInOut.UserId,
                CurrentDate = employeeClockInOut.CurrentDate,
                ClockInTime = employeeClockInOut.ClockInTime,
                ClockedIn = employeeClockInOut.ClockedIn,
                ClockOutTime = employeeClockInOut.ClockOutTime,
                ClockedOut = employeeClockInOut.ClockedOut,
                UpdatedDateTime = employeeClockInOut.UpdatedDateTime,
                UpdatedBy = employeeClockInOut.UpdatedBy,
                IsActive = employeeClockInOut.IsActive,
                LoggedTime = DateTime.Now
            };
            await _db.ClockInOutLogs.AddAsync(clockInOutLog);
        }

        public Task DeleteEmployeeClockInOut(EmployeeClockInClockOut employeeClockInOut)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee?> GetEmployeeById(int empId)
        {
            return await _db.Employees.FindAsync(empId);
        }

        public async Task<Employee?> GetEmployeeByUserId(string userId)
        {
            return await _db.Employees.FirstOrDefaultAsync(a => a.UserId == userId);
        }

        public async Task<EmployeeClockInClockOut?> GetEmployeeClockInOut(int empId, DateTime date)
        {
            return await _db.EmployeeClockInClockOuts.FirstOrDefaultAsync(a => a.EmployeeId == empId && a.CurrentDate == date);
        }

        public async Task SaveClockInOut()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateEmployeeClockInOut(EmployeeClockInClockOut employeeClockInOut)
        {
            _db.EmployeeClockInClockOuts.Update(employeeClockInOut);
            await AddClockInOutLog(employeeClockInOut);
            await _db.SaveChangesAsync();
        }
    }
}
