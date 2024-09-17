namespace AutomatedReportCore.Responces.DTOs
{
    public class StudentDto : StudentAttendanceDto
    {
        public string Gender { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string Father_Name { get; set; }
        public string Father_Phone { get; set; }
        public string Mother_Name { get; set; }
        public string Mother_Phone { get; set; }
        public bool DefaultParentPhonIsFather { get; set; }
        public double Total_Payments { get; set; }
        public double agreedMonthlyPayment { get; set; }
        public double Avg { get; set; }
        public string Division { get; set; }
    }
}
