namespace AutomatedReportCore.Responces.DTOs
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
