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
    public class Sessions_RecordController : ControllerBase, ISessions_RecordService<IActionResult>
    {
        private readonly ISessions_RecordService<GeneralResponse> sessionService;
        public Sessions_RecordController(ISessions_RecordService<GeneralResponse> sessionService)
        {
            this.sessionService = sessionService;
        }

        [HttpPost("AddSession")]
        public async Task<IActionResult> AddSession([Required,FromBody] AddSessionRequste requste)
        {
            try
            {
                var Result = await sessionService.AddSession(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteSession")]
        public async Task<IActionResult> DeleteSession([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await sessionService.DeleteSession(id);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditeSession")]
        public async Task<IActionResult> EditeSession([Required,FromBody] EditeSessionRequste requste)
        {
            try
            {
                var Result = await sessionService.EditeSession(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllDays")]
        public async Task<IActionResult> GetAllDays()
        {
            try
            {
                var Result = await sessionService.GetAllDays();
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllSessions")]
        public async Task<IActionResult> GetAllSessions([Required,FromQuery] Guid divisionId)
        {
            try
            {
                var Result = await sessionService.GetAllSessions(divisionId);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllSessionsByDay")]
        public async Task<IActionResult> GetAllSessionsByDay([Required,FromQuery] GetAllSessionsByDayRequste requste)
        {
            try
            {
                var Result = await sessionService.GetAllSessionsByDay(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllSessionsGroupedByDays")]
        public async Task<IActionResult> GetAllSessionsGroupedByDays([Required, FromQuery] Guid divisionId)
        {
            try
            {
                var Result = await sessionService.GetAllSessionsGroupedByDays(divisionId);
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
