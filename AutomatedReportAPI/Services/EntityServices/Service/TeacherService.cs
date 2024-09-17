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
    public class TeacherService : ITeacherService<GeneralResponse>
    {
        private readonly IUnitOfWork<Teacher> teacherRepository;
        public TeacherService(IUnitOfWork<Teacher> teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public async Task<GeneralResponse> AddTeacher(AddTeacherRequste requste)
        {
            GeneralResponse response;
            try
            {
                await teacherRepository.Create(new Teacher()
                {
                    Full_Name = requste.full_Name,
                    Phone = requste.phone
                });

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Teacher Added Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> DeleteTeacher(Guid id)
        {
            GeneralResponse response;
            try
            {
                await teacherRepository.Delete(id);

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Teacher Deleted Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> EditeTeacher(EditeTeacherRequste requste)
        {
            GeneralResponse response;
            try
            {
                var teacher = await teacherRepository.GetById(requste.id);
                if (teacher is not null)
                {
                    await teacherRepository.Update(new Teacher()
                    {
                        Id = requste.id,
                        Full_Name = requste.full_Name,
                        Phone = requste.phone
                    });

                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.Accepted;
                    response.Message = "Teacher Updated Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "Teacher Not Found !!";
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

        public async Task<GeneralResponse> GetAllTeachers()
        {
            var Data = new GetAllTeachersResponse();
            GeneralResponse response;
            try
            {
                var Teachers = teacherRepository.GetAll();
                if (Teachers.Count() != 0)
                {
                    foreach (var item in Teachers)
                    {
                        Data.teachers.Add(new TeacherDto()
                        {
                            Id = item.Id,
                            Full_Name = item.Full_Name,
                            Phone = item.Phone
                        });
                    }
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Teachers Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Teachers Found !!";
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

        public async Task<GeneralResponse> GetTeacherById(Guid id)
        {
            var Data = new GetTeacherByIdResponse();
            GeneralResponse response;
            try
            {
                var teacher = await teacherRepository.GetById(id);
                if (teacher is not null)
                {
                    Data.teacher = new TeacherDto()
                    {
                        Id = teacher.Id,
                        Full_Name = teacher.Full_Name,
                        Phone = teacher.Phone
                    };
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Teacher Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Teacher Found !!";
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
