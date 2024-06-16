using ERM.Data;
using ERM.Models;
using ERM.Models.DTOs;
using ERM.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ERM.Controllers
{
    public class ClockInClockOutController : Controller
    {
        private readonly IClockInOutRepository _clockInOutRepository;
        private readonly IUserRepository _userRepository;
        public ClockInClockOutController(IClockInOutRepository clockInOutRepository, IUserRepository userRepository)
        {
            _clockInOutRepository = clockInOutRepository;
            _userRepository = userRepository;

        }
        public async Task<IActionResult> Index()
        {
            ClockInOutDTO clockInOutDTO = await GetClockInOutDTO();            
            return View(clockInOutDTO);
        }

        private async Task<ClockInOutDTO> GetClockInOutDTO()
        {
            ClockInOutDTO clockInOutDTO = new ClockInOutDTO();
            clockInOutDTO.CurrentDate = DateTime.Now.Date;

            var userId = _userRepository.GetUserId();

            var employee = await _clockInOutRepository.GetEmployeeByUserId(userId);
            if (employee != null)
            {
                var employeeClockInOut = await _clockInOutRepository.GetEmployeeClockInOut(employee.EmployeeId, clockInOutDTO.CurrentDate);
                if (employeeClockInOut != null)
                {
                    clockInOutDTO.EmployeeClockInClockOut = employeeClockInOut;
                }
                else
                {
                    clockInOutDTO.EmployeeClockInClockOut = new EmployeeClockInClockOut()
                    {
                        UserId = userId,
                        EmployeeId = employee.EmployeeId,
                        CurrentDate = DateTime.Now.Date,
                        IsActive = true
                    };
                }

                clockInOutDTO.EmployeeName = employee.FirstName + " " + employee.LastName;
                clockInOutDTO.EmployeeClockInClockOut.EmployeeId = employee.EmployeeId;
            }
            return clockInOutDTO;
        }

        [HttpPost]
        public async Task<IActionResult> ClockIn(int empId, string currentDate)
        {
            ClockInOutDTO clockInOutDTO = await GetClockInOutDTO();
            if(clockInOutDTO != null)
            {
                if(clockInOutDTO.EmployeeClockInClockOut != null)
                {
                    clockInOutDTO.EmployeeClockInClockOut.ClockedIn = true;
                    clockInOutDTO.EmployeeClockInClockOut.ClockInTime = DateTime.Now;
                    clockInOutDTO.EmployeeClockInClockOut.UpdatedDateTime = DateTime.Now;
                    clockInOutDTO.EmployeeClockInClockOut.UpdatedBy = clockInOutDTO.EmployeeName;
                    await _clockInOutRepository.AddEmployeeClockInOut(clockInOutDTO.EmployeeClockInClockOut);
                }
            }
            return View("Index", clockInOutDTO);
        }
       
        public IActionResult ClockOut(ClockInOutDTO clockInOutDTO)
        {
            clockInOutDTO.EmployeeClockInClockOut.ClockedOut = true;
            clockInOutDTO.EmployeeClockInClockOut.ClockInTime = DateTime.Now;
            clockInOutDTO.EmployeeClockInClockOut.UpdatedDateTime = DateTime.Now;
            clockInOutDTO.EmployeeClockInClockOut.UpdatedBy = clockInOutDTO.EmployeeName;
            _clockInOutRepository.UpdateEmployeeClockInOut(clockInOutDTO.EmployeeClockInClockOut);
            return View("Index", clockInOutDTO);
        }

        public IActionResult SaveClockInOut(ClockInOutDTO clockInOutDTO)
        {
            _clockInOutRepository.SaveClockInOut();
            return View("Index", clockInOutDTO);
        }

    }
}
