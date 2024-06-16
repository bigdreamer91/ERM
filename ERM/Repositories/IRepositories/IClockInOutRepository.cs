using ERM.Models;

namespace ERM.Repositories.IRepositories
{
    public interface IClockInOutRepository
    {
        Task<Employee?> GetEmployeeById(int empId);
        Task<Employee?> GetEmployeeByUserId(string userId);
        Task<EmployeeClockInClockOut?> GetEmployeeClockInOut(int empId, DateTime date);
        Task AddEmployeeClockInOut(EmployeeClockInClockOut employeeClockInOut);
        Task DeleteEmployeeClockInOut(EmployeeClockInClockOut employeeClockInOut);
        Task UpdateEmployeeClockInOut(EmployeeClockInClockOut employeeClockInOut);
        Task SaveClockInOut();
    }
}
