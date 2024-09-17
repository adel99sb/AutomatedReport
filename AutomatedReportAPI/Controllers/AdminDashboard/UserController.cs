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
    public class UserController : ControllerBase , IUserService<IActionResult>
    {
        private readonly IUserService<GeneralResponse> userService;
        public UserController(IUserService<GeneralResponse> userService)
        {
            this.userService = userService;
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login([Required,FromQuery] LoginRequste request)
        {
            try
            {
                var Result = await userService.Login(request);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var Result = await userService.GetAllUsers();
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditeUserPassword")]
        public async Task<IActionResult> EditeUserPassword([Required,FromQuery] EditeUserPasswordRequste request)
        {
            try
            {
                var Result = await userService.EditeUserPassword(request);
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
