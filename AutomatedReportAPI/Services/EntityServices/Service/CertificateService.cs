using AutomatedReportAPI.AppData.Models;
using AutomatedReportAPI.Infrastructure;
using AutomatedReportAPI.Services.EntityServices.Contracts;
using AutomatedReportCore.Enums;
using AutomatedReportCore.Responces;
using AutomatedReportCore.Responces.AdminDashboard;
using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportAPI.Services.EntityServices.Service
{
    public class CertificateService : ICertificateService<GeneralResponse>
    {
        private readonly IUnitOfWork<Certificate> certificateRepository;
        public CertificateService(IUnitOfWork<Certificate> certificateRepository)
        {
            this.certificateRepository = certificateRepository;
        }
        public async Task<GeneralResponse> GetAllCertificates()
        {
            var Data = new GetAllCertificatesResponse();            
            GeneralResponse response;
            try
            {
                var Certificates = certificateRepository.GetAll();
                foreach (var certificate in Certificates)
                {
                    Data.certificates.Add(new CertificateDto()
                    {
                        Id = certificate.Id,
                        Name = certificate.Name
                    });
                }
                if (Data.certificates.Count != 0)
                {
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Certificates Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Certificates Found !!";
                }
            }
            catch (Exception ex)
            {
                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
