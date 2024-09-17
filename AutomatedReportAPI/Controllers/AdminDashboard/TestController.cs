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
    public class TestController : ControllerBase, ITestService<IActionResult>
    {
        private readonly ITestService<GeneralResponse> testService;
        public TestController(ITestService<GeneralResponse> testService)
        {
            this.testService = testService;
        }

        [HttpPost("AddTest")]
        public async Task<IActionResult> AddTest([Required,FromBody] AddTestRequste requste)
        {
            try
            {
                var Result = await testService.AddTest(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteTest")]
        public async Task<IActionResult> DeleteTest([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await testService.DeleteTest(id);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditeTest")]
        public async Task<IActionResult> EditeTest([Required,FromBody] EditeTestRequste requste)
        {
            try
            {
                var Result = await testService.EditeTest(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllTests")]
        public async Task<IActionResult> GetAllTests([Required,FromQuery] Guid divisionId)
        {
            try
            {
                var Result = await testService.GetAllTests(divisionId);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTestById")]
        public async Task<IActionResult> GetTestById([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await testService.GetTestById(id);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("MarkAsDone")]
        public async Task<IActionResult> MarkAsDone([Required, FromQuery] Guid id)
        {
            try
            {
                var Result = await testService.MarkAsDone(id);
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
