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
    public class StudentController : ControllerBase, IStudentService<IActionResult>
    {
        private readonly IStudentService<GeneralResponse> studentService;
        public StudentController(IStudentService<GeneralResponse> studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([Required,FromBody] AddStudentRequste requste)
        {
            try
            {
                var Result = await studentService.AddStudent(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await studentService.DeleteStudent(id);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditeStudent")]
        public async Task<IActionResult> EditeStudent([Required,FromBody] EditeStudentRequste requste)
        {
            try
            {
                var Result = await studentService.EditeStudent(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllStudentsByDivisionId")]
        public async Task<IActionResult> GetAllStudentsByDivisionId([Required,FromQuery] Guid divisionId)
        {
            try
            {
                var Result = await studentService.GetAllStudentsByDivisionId(divisionId);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllStudentsByTestId")]
        public async Task<IActionResult> GetAllStudentsByTestId([Required,FromQuery] Guid testId)
        {
            //try
            //{
            //    var Result = await studentService.GetAllStudentsByTestId(testId);
            //    var Response = Result.StatusCode.ToActionResult(Result);
            //    return Response;
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            throw new NotImplementedException();
        }
        [HttpGet("GetAllStudentsWithDivision")]
        public async Task<IActionResult> GetAllStudentsWithDivision()
        {
            try
            {
                var Result = await studentService.GetAllStudentsWithDivision();
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetStudentById")]
        public async Task<IActionResult> GetStudentById([Required, FromQuery] Guid id)
        {
            try
            {
                var Result = await studentService.GetStudentById(id);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("MoveStudentToGratitude")]
        public async Task<IActionResult> MoveStudentToGratitude(Guid id)
        {
            try
            {
                var Result = await studentService.MoveStudentToGratitude(id);
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
