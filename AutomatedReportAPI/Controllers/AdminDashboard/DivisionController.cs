using AutomatedReportAPI.AppData.Models;
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
    public class DivisionController : ControllerBase, IDivisionService<IActionResult>
    {
        private readonly IDivisionService<GeneralResponse> divisionService;
        public DivisionController(IDivisionService<GeneralResponse> divisionService)
        {
            this.divisionService = divisionService;            
        }
        [HttpPost("AddDivision")]
        public async Task<IActionResult> AddDivision([Required,FromBody] AddDivisionRequste requste)
        {
            try
            {
                var Result = await divisionService.AddDivision(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteDivision")]
        public async Task<IActionResult> DeleteDivision([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await divisionService.DeleteDivision(id);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditeDivision")]
        public async Task<IActionResult> EditeDivision([Required, FromBody] EditeDivisionRequste requste)
        {
            try
            {
                var Result = await divisionService.EditeDivision(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllDivisions")]
        public async Task<IActionResult> GetAllDivisions([FromQuery]Guid? certificateId)
        {
            try
            {
                var Result = await divisionService.GetAllDivisions(certificateId);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllDivisionsWithStudentsNomber")]
        public async Task<IActionResult> GetAllDivisionsWithStudentsNomber([Required,FromQuery]Guid certificateId)
        {
            try
            {
                var Result = await divisionService.GetAllDivisionsWithStudentsNomber(certificateId);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetDivisionById")]
        public async Task<IActionResult> GetDivisionById([Required,FromQuery] Guid id)
        {
            try
            {
                var Result = await divisionService.GetDivisionById(id);
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
