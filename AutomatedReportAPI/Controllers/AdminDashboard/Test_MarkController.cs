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
    public class Test_MarkController : ControllerBase, ITestMarkService<IActionResult>
    {
        private readonly ITestMarkService<GeneralResponse> testMarkService;
        public Test_MarkController(ITestMarkService<GeneralResponse> testMarkService)
        {
            this.testMarkService = testMarkService;
        }

        [HttpPost("AddTestMarks")]
        public async Task<IActionResult> AddTestMarks([Required,FromBody] AddTestMarkRequste requste)
        {
            //try
            //{
            //    var Result = await testMarkService.AddTestMarks(requste);
            //    var Response = Result.StatusCode.ToActionResult(Result);
            //    return Response;
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            throw new NotImplementedException();
        }
        [HttpGet("GetAllTestMarks")]
        public async Task<IActionResult> GetAllTestMarks([Required,FromQuery] Guid testId)
        {
            try
            {
                var Result = await testMarkService.GetAllTestMarks(testId);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateTestMarks")]
        public async Task<IActionResult> UpdateTestMarks([Required,FromBody] EditeTestMarksRequste requste)
        {
            try
            {
                var Result = await testMarkService.UpdateTestMarks(requste);
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
