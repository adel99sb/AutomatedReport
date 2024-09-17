using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class GratitudeStudent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(50)]
        public string First_Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Last_Name { get; set; }
        [Required]
        [StringLength(5)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        [StringLength(16)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Father_Name { get; set; }
        [Required]
        [StringLength(16)]
        public string Father_Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Mother_Name { get; set; }
        [Required]
        [StringLength(16)]
        public string Mother_Phone { get; set; }
        [Required]
        public bool DefaultParentPhonIsFather { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Total_Payments { get; set; }
        [Range(0, double.MaxValue)]
        public double agreedMonthlyPayment { get; set; }        
        public double Avg {  get; set; }
    }
}
