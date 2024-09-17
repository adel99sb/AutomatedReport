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
    public class ClassController : ControllerBase, IClassService<IActionResult>
    {
        private readonly IClassService<GeneralResponse> classService;
        public ClassController(IClassService<GeneralResponse> classService)
        {
            this.classService = classService;
        }

        [HttpPost("AddClass")]
        public async Task<IActionResult> AddClass([Required,FromBody]AddClassRequste requste)
        {
            try
            {
                var Result = await classService.AddClass(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteClass")]
        public async Task<IActionResult> DeleteClass([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await classService.DeleteClass(id);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditeClass")]
        public async Task<IActionResult> EditeClass([Required,FromBody] EditeClassRequste requste)
        {
            try
            {
                var Result = await classService.EditeClass(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllClasses")]
        public async Task<IActionResult> GetAllClasses()
        {
            try
            {
                var Result = await classService.GetAllClasses();
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetClassById")]
        public async Task<IActionResult> GetClassById([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await classService.GetClassById(id);
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
