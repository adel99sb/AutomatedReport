using AutomatedReportCore.Responces.DTOs;
using System;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllCertificatesResponse
    {
        public List<CertificateDto> certificates { get; set; } = new();
    }
}
