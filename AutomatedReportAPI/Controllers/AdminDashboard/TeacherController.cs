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
    public class TeacherController : ControllerBase, ITeacherService<IActionResult>
    {
        private readonly ITeacherService<GeneralResponse> teacherService;
        public TeacherController(ITeacherService<GeneralResponse> teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher([Required,FromBody] AddTeacherRequste requste)
        {
            try
            {
                var Result = await teacherService.AddTeacher(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacher([Required, FromQuery] Guid id)
        {
            try
            {
                var Result = await teacherService.DeleteTeacher(id);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditeTeacher")]
        public async Task<IActionResult> EditeTeacher([Required,FromBody] EditeTeacherRequste requste)
        {
            try
            {
                var Result = await teacherService.EditeTeacher(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllTeachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var Result = await teacherService.GetAllTeachers();
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTeacherById")]
        public async Task<IActionResult> GetTeacherById([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await teacherService.GetTeacherById(id);
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
