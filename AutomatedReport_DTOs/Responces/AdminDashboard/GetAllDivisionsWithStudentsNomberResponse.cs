using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllDivisionsWithStudentsNomberResponse
    {
        public List<DivisionsWithStudentsNomberDto> divisions { get; set; } = new();
    }
}
