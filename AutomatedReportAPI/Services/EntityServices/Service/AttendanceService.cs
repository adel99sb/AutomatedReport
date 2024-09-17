using AutomatedReportAPI.AppData.Models;
using AutomatedReportAPI.Infrastructure;
using AutomatedReportAPI.Services.EntityServices.Contracts;
using AutomatedReportCore.Enums;
using AutomatedReportCore.Requstes.AdminDashboard;
using AutomatedReportCore.Requstes.DTOs;
using AutomatedReportCore.Responces;
using AutomatedReportCore.Responces.AdminDashboard;
using Microsoft.EntityFrameworkCore;

namespace AutomatedReportAPI.Services.EntityServices.Service
{
    public class AttendanceService : IAttendanceService<GeneralResponse>
    {
        private readonly IUnitOfWork<Attendance> attendanceRepository;
        private readonly IUnitOfWork<DailySessions_Record> dailySessions_RecordRepository;
        public AttendanceService(IUnitOfWork<Attendance> attendanceRepository,
            IUnitOfWork<DailySessions_Record> dailySessions_RecordRepository)
        {
            this.attendanceRepository = attendanceRepository;
            this.dailySessions_RecordRepository = dailySessions_RecordRepository;
        }

        public async Task<GeneralResponse> EditeAttendance(EditeAttendanceRequste requste)
        {
            GeneralResponse response;
            try
            {
                foreach (var item in requste.AttendancesList)
                {
                    var newAttendance = await attendanceRepository.GetById(item.Id);
                    newAttendance.IsAttend = item.IsAttend;
                    await attendanceRepository.Update(newAttendance);
                }
                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Attendances Edited Succesfully";
            }
            catch (Exception ex)
            {
                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> GetAttendanceByDate(DateTime date, Guid DivisionId)
        {
            GeneralResponse response;
            try
            {
                var query = attendanceRepository.GetAll()
                    .Include(a => a.DailySessions_Record)
                        .ThenInclude(ds => ds.Sessions_Record)
                            .ThenInclude(s => s.Subject)
                    .Include(a => a.DailySessions_Record)
                        .ThenInclude(ds => ds.Sessions_Record)
                            .ThenInclude(s => s.Hall)
                    .Include(a => a.DailySessions_Record)
                        .ThenInclude(ds => ds.Sessions_Record)
                            .ThenInclude(s => s.Class)
                    .Include(a => a.DailySessions_Record)
                        .ThenInclude(ds => ds.Sessions_Record)
                            .ThenInclude(s => s.Division)
                    .Include(a => a.Student)
                    .Where(a => a.DailySessions_Record.Sessions_Record.DivisionId
                    == DivisionId && a.DailySessions_Record.Date.Date == date.Date)
                    .Select(a => new GetAttendanceDto
                    {
                        Time = a.DailySessions_Record.Sessions_Record.Class.Name,
                        Subject = a.DailySessions_Record.Sessions_Record.Subject.Name,
                        SubjectTitle = a.DailySessions_Record.Subject_Title,
                        Hall = a.DailySessions_Record.Sessions_Record.Hall.Name,
                        Day = a.DailySessions_Record.Sessions_Record.day.ToString(),
                        StudentAttendancs = new List<StudentAttendanc>
                        {
                            new StudentAttendanc
                            {
                                IsAttend = a.IsAttend,
                                StudentId = a.Student.Id,
                                FirstName = a.Student.First_Name,
                                LastName = a.Student.Last_Name,
                                Id = a.Id
                            }
                        }
                    }).ToList();

                var Data = new GetAttendanceByDateResponse
                {
                    attendances = query
                };
                if (Data.attendances.Count > 0)
                {
                    response = new GeneralResponse(Data);
                    response.Message = "Get All Attendances Succesfully";
                    response.StatusCode = Requests_Status.Ok;
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Attendances Found!!";
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
