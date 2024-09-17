using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Responces.DTOs
{
    public class ClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string From_Time { get; set; }
        public string To_Time { get; set; }
    }
}
