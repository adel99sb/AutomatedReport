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
    public class HallController : ControllerBase, IHallService<IActionResult>
    {
        private readonly IHallService<GeneralResponse> hallService;
        public HallController(IHallService<GeneralResponse> hallService)
        {
            this.hallService = hallService;
        }

        [HttpPost("AddHall")]
        public async Task<IActionResult> AddHall([Required,FromBody] AddHallRequste requste)
        {
            try
            {
                var Result = await hallService.AddHall(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteHall")]
        public async Task<IActionResult> DeleteHall([Required, FromQuery] Guid id)
        {
            try
            {
                var Result = await hallService.DeleteHall(id);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditeHall")]
        public async Task<IActionResult> EditeHall([Required,FromBody] EditeHallRequste requste)
        {
            try
            {
                var Result = await hallService.EditeHall(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllHalls")]
        public async Task<IActionResult> GetAllHalls()
        {
            try
            {
                var Result = await hallService.GetAllHalls();
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetHallById")]
        public async Task<IActionResult> GetHallById([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await hallService.GetHallById(id);
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
