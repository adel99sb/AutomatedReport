namespace AutomatedReportCore.Requstes.DTOs
{
    public class GetAttendanceDto
    {
        public string Time { get; set; }
        public string Subject { get; set; }
        public string SubjectTitle { get; set; }
        public string Hall { get; set; }        
        public string Day { get; set; }
        public List<StudentAttendanc> StudentAttendancs { get; set; } = new();
    }
    public class StudentAttendanc
    {
        public bool IsAttend { get; set; }
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Id { get; set; }
    }
}
