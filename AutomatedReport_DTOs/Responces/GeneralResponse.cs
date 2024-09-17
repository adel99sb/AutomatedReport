using AutomatedReportCore.Enums;

namespace AutomatedReportCore.Responces
{
    public class GeneralResponse
    {
        public string Message { get; set; }
        public Requests_Status StatusCode { get; set; }
        public object Data { get; }
        public GeneralResponse(object Data)
        {
            this.Data = Data;
        }
    }
}
