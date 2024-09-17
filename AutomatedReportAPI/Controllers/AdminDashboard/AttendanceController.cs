using AutomatedReportAPI.Services;
using AutomatedReportAPI.Services.EntityServices.Contracts;
using AutomatedReportCore.Requstes.AdminDashboard;
using AutomatedReportCore.Responces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.Controllers.AdminDashboard
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AttendanceController : ControllerBase, IAttendanceService<IActionResult>
    {
        private readonly IAttendanceService<GeneralResponse> attendanceService;
        public AttendanceController(IAttendanceService<GeneralResponse> attendanceService)
        {
            this.attendanceService = attendanceService;
        }
        
        [HttpPost("EditeAttendance")]
        public async Task<IActionResult> EditeAttendance([Required][FromBody] EditeAttendanceRequste requste)
        {
            try
            {
                var Result = await attendanceService.EditeAttendance(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAttendanceByDate")]        
        public async Task<IActionResult> GetAttendanceByDate([Required][FromQuery] DateTime date,[Required][FromQuery] Guid DivisionId)
        {
            try
            {
                var Result = await attendanceService.GetAttendanceByDate(date,DivisionId);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
