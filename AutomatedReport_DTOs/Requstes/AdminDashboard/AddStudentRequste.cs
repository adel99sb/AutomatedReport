using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class AddStudentRequste
    {
        [Required(ErrorMessage = "First Name Filed Is Required")]
        public string first_Name { get; set; }
        [Required(ErrorMessage = "Last Name Filed Is Required")]
        public string last_Name { get; set; }
        [Required(ErrorMessage = "Gender Filed Is Required")]
        public string gender { get; set; }
        public string? address { get; set; }
        [Required(ErrorMessage = "Birth Day Filed Is Required")]
        public DateTime birthDay { get; set; }
        [Required(ErrorMessage = "Phone Filed Is Required")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Father Name Filed Is Required")]
        public string father_Name { get; set; }
        [Required(ErrorMessage = "Father Phone Filed Is Required")]
        public string father_Phone { get; set; }
        [Required(ErrorMessage = "Mother Name Filed Is Required")]
        public string mother_Name { get; set; }
        [Required(ErrorMessage = "Mother Phone Filed Is Required")]
        public string mother_Phone { get; set; }
        [Required(ErrorMessage = "Set Default Parent Phone Nomber Is Required")]
        public bool defaultParentPhonIsFather { get; set; }
        [Required(ErrorMessage = "Total Payments Filed Is Required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Payments Filed can not be a negative value")]
        public double total_Payments { get; set; }
        [Required(ErrorMessage = "Agreed monthly payment Filed Is Required")]
        [Range(0, double.MaxValue, ErrorMessage = "Agreed monthly payment Filed can not be a negative value")]
        public double agreedMonthlyPayment { get; set; }
        [Required(ErrorMessage = "Division Id Filed Is Required")]
        public Guid divisionId { get; set; }
    }
}
