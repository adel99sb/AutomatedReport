using AutomatedReportAPI.AppData.Models;
using AutomatedReportAPI.Infrastructure;
using AutomatedReportAPI.Services.EntityServices.Contracts;
using AutomatedReportCore.Enums;
using AutomatedReportCore.Requstes.AdminDashboard;
using AutomatedReportCore.Responces;
using AutomatedReportCore.Responces.AdminDashboard;
using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportAPI.Services.EntityServices.Service
{
    public class ClassService : IClassService<GeneralResponse>
    {
        private readonly IUnitOfWork<_Class> classRepository;
        public ClassService(IUnitOfWork<_Class> classRepository)
        {
            this.classRepository = classRepository;
        }

        public async Task<GeneralResponse> AddClass(AddClassRequste requste)
        {
            GeneralResponse response;
            try
            {
                await classRepository.Create(new _Class()
                {
                    Name = requste.name,
                    From_Time = requste.from_Time,
                    To_Time = requste.to_Time
                });

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Class Added Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> DeleteClass(Guid id)
        {
            GeneralResponse response;
            try
            {
                await classRepository.Delete(id);

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Class Deleted Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> EditeClass(EditeClassRequste requste)
        {
            GeneralResponse response;
            try
            {
                var _class = await classRepository.GetById(requste.id);
                if (_class is not null)
                {
                    await classRepository.Update(new _Class()
                    {
                        Id = requste.id,
                        Name = requste.name,
                        From_Time = requste.from_Time,
                        To_Time = requste.to_Time                        
                    });

                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.Accepted;
                    response.Message = "Class Updated Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "Class Not Found !!";
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

        public async Task<GeneralResponse> GetAllClasses()
        {
            var Data = new GetAllClassesResponse();
            GeneralResponse response;
            try
            {
                var Classes = classRepository.GetAll();                
                if (Classes.Count() != 0)
                {
                    foreach (var item in Classes)
                    {
                        Data.classes.Add(new ClassDto()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            From_Time = item.From_Time,
                            To_Time = item.To_Time
                        });
                    }
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Classes Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Classes Found !!";
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

        public async Task<GeneralResponse> GetClassById(Guid id)
        {
            var Data = new GetClassByIdResponse();
            GeneralResponse response;
            try
            {
                var _class = await classRepository.GetById(id);
                if (_class is not null)
                {
                    Data.Class = new ClassDto()
                    {
                        Id = _class.Id,
                        Name = _class.Name,
                        From_Time = _class.From_Time,
                        To_Time = _class.To_Time
                    };
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Class Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Class Found !!";
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
