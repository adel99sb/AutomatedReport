using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllPaymentsResponse
    {
        public List<PaymentDto> payments { get; set; } = new();
        public double Sum { get; set; }        
    }    
}
