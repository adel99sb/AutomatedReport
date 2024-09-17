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
    public class DailySessionsController : ControllerBase, IDailySessionsService<IActionResult>
    {
        private readonly IDailySessionsService<GeneralResponse> dailySessionsService;
        public DailySessionsController(IDailySessionsService<GeneralResponse> dailySessionsService)
        {
            this.dailySessionsService = dailySessionsService;
        }

        [HttpPost("AddDailySessions")]
        public async Task<IActionResult> AddDailySessions([Required, FromBody] AddDailySessionsRequste requste)
        {
            try
            {
                var Result = await dailySessionsService.AddDailySessions(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllDailySessions")]
        public async Task<IActionResult> GetAllDailySessions([Required, FromQuery] Guid divissionId)
        {
            try
            {
                var Result = await dailySessionsService.GetAllDailySessions(divissionId);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllDailySessionsByDate")]
        public async Task<IActionResult> GetAllDailySessionsByDate([Required, FromQuery] GetAllDailySessionsByDateRequste requste)
        {
            try
            {
                var Result = await dailySessionsService.GetAllDailySessionsByDate(requste);
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