using AutomatedReportAPI.AppData.Models;
using AutomatedReportAPI.Infrastructure;
using AutomatedReportAPI.Services.EntityServices.Contracts;
using AutomatedReportCore.Enums;
using AutomatedReportCore.Responces;
using AutomatedReportCore.Responces.AdminDashboard;
using AutomatedReportCore.Responces.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AutomatedReportAPI.Services.EntityServices.Service
{
    public class SubjectService : ISubjectService<GeneralResponse>
    {
        private readonly IUnitOfWork<Subject> subjectRepository;
        private readonly IUnitOfWork<Division> divisionRepository;
        public SubjectService(IUnitOfWork<Subject> subjectRepository,
            IUnitOfWork<Division> divisionRepository)
        {
            this.subjectRepository = subjectRepository;
            this.divisionRepository = divisionRepository;
        }

        public async Task<GeneralResponse> GetAllSubjects(Guid divisionId)
        {
            var Data = new GetAllSubjectsResponse();
            GeneralResponse response;
            try
            {
                var CertificateId = divisionRepository.GetAll()
                    .Include(c => c.Certificate)
                    .Where(c => c.Certificate.Id == divisionId)
                    .FirstOrDefault()?.Certificate.Id;
                var Subjects = subjectRepository.GetAll()
                    .Include(c => c.Certificate)
                    .Where(c => c.Certificate.Id == CertificateId);
                if(Subjects.Count() != 0)
                {
                    foreach (var item in Subjects)
                    {
                        Data.subjects.Add(new SubjectDto()
                        {
                            Id = item.Id,
                            Name = item.Name
                        });
                    }
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Subjects Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Subjects Found !!";
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
