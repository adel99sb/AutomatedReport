using AutomatedReportCore.Requstes.DTOs;
using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class AddTestMarkRequste
    {
        [Required(ErrorMessage = "Test Marks List Filed Is Required")]
        public List<TestMarkDto> TestMarksList { get; set; } = new();
    }
}
