using AutomatedReportAPI.Services;
using AutomatedReportAPI.Services.EntityServices.Contracts;
using AutomatedReportCore.Responces;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedReportAPI.Controllers.AdminDashboard
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GlobalController : ControllerBase, IGlobalService<IActionResult>
    {
        private readonly IGlobalService<GeneralResponse> _globalService;
        public GlobalController(IGlobalService<GeneralResponse> globalService)
        {
            this._globalService = globalService;
        }
        [HttpGet("GetAllPhoneNumbers")]
        public async Task<IActionResult> GetAllPhoneNumbers()
        {
            try
            {
                var Result = await _globalService.GetAllPhoneNumbers();
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllStatistics")]
        public async Task<IActionResult> GetAllStatistics()
        {
            try
            {
                var Result = await _globalService.GetAllStatistics();
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTodayBirthDayNumbers")]
        public async Task<IActionResult> GetTodayBirthDayNumbers()
        {
            try
            {
                var Result = await _globalService.GetTodayBirthDayNumbers();
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
