using AutomatedReportAPI.AppData.Models;
using AutomatedReportAPI.Infrastructure;
using AutomatedReportAPI.Services.EntityServices.Contracts;
using AutomatedReportCore.Enums;
using AutomatedReportCore.Requstes.AdminDashboard;
using AutomatedReportCore.Responces;
using AutomatedReportCore.Responces.AdminDashboard;
using AutomatedReportCore.Responces.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AutomatedReportAPI.Services.EntityServices.Service
{
    public class DivisionService : IDivisionService<GeneralResponse>
    {
        private readonly IUnitOfWork<Division> divisionRepository;
        private readonly IUnitOfWork<Certificate> certificateRepository;
        private readonly IUnitOfWork<Student> studentRepository;
        public DivisionService(IUnitOfWork<Division> divisionRepository,
            IUnitOfWork<Certificate> certificateRepository,
            IUnitOfWork<Student> studentRepository)
        {
            this.divisionRepository = divisionRepository;
            this.certificateRepository = certificateRepository;
            this.studentRepository = studentRepository;
        }

        public async Task<GeneralResponse> AddDivision(AddDivisionRequste requste)
        {
            GeneralResponse response;
            try
            {
                var certificate = await certificateRepository.GetById(requste.certificateId);
                if (certificate is not null)
                {
                    await divisionRepository.Create(new Division()
                    {
                        Name = requste.name,
                        CertificateId = certificate.Id
                    });

                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.Accepted;
                    response.Message = "Division Added Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "Certificate Not Found !!";
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

        public async Task<GeneralResponse> DeleteDivision(Guid id)
        {
            GeneralResponse response;
            try
            {
                await divisionRepository.Delete(id);

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Division Deleted Succesfully";
            }
            catch (Exception ex)
            {
                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> EditeDivision(EditeDivisionRequste requste)
        {
            GeneralResponse response;
            try
            {
                var division = await divisionRepository.GetById(requste.id);
                var certificate = await certificateRepository.GetById(requste.certificateId);
                if (division is not null)
                {
                    if (certificate is not null)
                    {
                        await divisionRepository.Update(new Division()
                        {
                            Id = requste.id,
                            Name = requste.name,
                            Certificate = certificate
                        });

                        response = new GeneralResponse(null);
                        response.StatusCode = Requests_Status.Accepted;
                        response.Message = "Division Updated Succesfully";
                    }
                    else
                    {
                        response = new GeneralResponse(null);
                        response.StatusCode = Requests_Status.NotFound;
                        response.Message = "Certificate Not Found !!";
                    }
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "Division Not Found !!";
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

        public async Task<GeneralResponse> GetAllDivisions(Guid? certificateId)
        {
            var Data = new GetAllDivisionsResponse();
            GeneralResponse response;
            try
            {
                var divisions = divisionRepository.GetAll();
                if (certificateId.HasValue)
                {
                    divisions = divisions
                        .Where(c => c.Certificate.Id == certificateId);
                }
                divisions = divisions.Include(c => c.Certificate);
                if (divisions.Count() != 0)
                {
                    foreach (var item in divisions)
                    {
                        Data.divisions.Add(new DivisionDto()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            CertificateName = item.Certificate.Name
                        });
                    }
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Divisions Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Divisions Found !!";
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

        public async Task<GeneralResponse> GetAllDivisionsWithStudentsNomber(Guid certificateId)
        {
            var Data = new GetAllDivisionsWithStudentsNomberResponse();
            GeneralResponse response;
            try
            {
                var divisions = divisionRepository.GetAll()
                        .Where(c => c.Certificate.Id == certificateId);
                var students = studentRepository.GetAll().Include(d => d.Division).ToList();
                if (divisions.Count() != 0)
                {
                    int studentNomber;
                    foreach (var item in divisions)
                    {
                        studentNomber = students
                            .Where(d => d.Division.Id == item.Id).Count();
                        Data.divisions.Add(new DivisionsWithStudentsNomberDto()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            StudentsNomber = studentNomber
                        });
                    }
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Divisions Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Divisions Found !!";
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

        public async Task<GeneralResponse> GetDivisionById(Guid id)
        {
            var Data = new GetDivisioneByIdResponse();
            GeneralResponse response;
            try
            {
                var division = divisionRepository.GetAll()
                    .Where(d => d.Id == id)
                    .Include(c => c.Certificate)
                    .FirstOrDefault();
                if (division is not null)
                {
                    Data.division = new DivisionDto()
                    {
                        Id = division.Id,
                        Name = division.Name,
                        CertificateName = division.Certificate.Name
                    };
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Division Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Division Found !!";
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
