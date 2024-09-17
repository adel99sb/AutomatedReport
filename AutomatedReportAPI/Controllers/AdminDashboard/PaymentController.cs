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
    public class PaymentController : ControllerBase, IPaymentService<IActionResult>
    {
        private readonly IPaymentService<GeneralResponse> paymentService;
        public PaymentController(IPaymentService<GeneralResponse> paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost("AddPayment")]
        public async Task<IActionResult> AddPayment([Required,FromBody] AddPaymentRequste requste)
        {
            try
            {
                var Result = await paymentService.AddPayment(requste);
                var Response = Result.StatusCode.ToActionResult(Result);
                return Response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllPayments")]
        public async Task<IActionResult> GetAllPayments([Required,FromQuery] Guid studentId)
        {
            try
            {
                var Result = await paymentService.GetAllPayments(studentId);
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
