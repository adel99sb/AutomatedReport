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
    public class DailySessionsService : IDailySessionsService<GeneralResponse>
    {
        private readonly IUnitOfWork<DailySessions_Record> dailySessions_RecordRepository;
        private readonly IUnitOfWork<Sessions_Record> Sessions_RecordRepository;
        private readonly IUnitOfWork<Attendance> attendanceRepository;
        private readonly IUnitOfWork<Student> studentRepository;
        public DailySessionsService(
            IUnitOfWork<DailySessions_Record> dailySessions_RecordRepository,
            IUnitOfWork<Sessions_Record> sessions_RecordRepository,
            IUnitOfWork<Attendance> attendanceRepository,
            IUnitOfWork<Student> studentRepository)
        {
            this.dailySessions_RecordRepository = dailySessions_RecordRepository;
            Sessions_RecordRepository = sessions_RecordRepository;
            this.attendanceRepository = attendanceRepository;
            this.studentRepository = studentRepository;
        }
        private async Task AddDefualtAttendencToDailySession(Guid DailySessinId)
        {
            var DailySession = await dailySessions_RecordRepository.GetById(DailySessinId);
            var SessionRecord = await Sessions_RecordRepository.GetById(DailySession.Sessions_RecordId);
            var StudentsIdList = studentRepository.GetAll()
                .Where(s => s.DivisionId == SessionRecord.DivisionId)
                .Select(s => s.Id).ToList();
            foreach (var id in StudentsIdList)
            {
                await attendanceRepository.Create(new Attendance()
                {
                    DailySessions_RecordId = DailySessinId,
                    IsAttend = false,
                    StudentId = id
                });
            }
        }
        public async Task<GeneralResponse> AddDailySessions(AddDailySessionsRequste requste)
        {
            GeneralResponse response;
            try
            {
                var Sessions_Records = Sessions_RecordRepository.GetAll()
                    .ToList();
                foreach (var item in requste.DailySessionList)
                {                    
                    if (!item.IsAlreadyExist)
                    {
                        var Sessions_Record = Sessions_Records
                            .Find(sr => sr.Id == item.Sessions_RecordId);
                        var newDailySession = new DailySessions_Record()
                        {
                            Date = item.Date,
                            Sessions_RecordId = Sessions_Record.Id,
                            Subject_Title = item.Subject_Title
                        };
                        await dailySessions_RecordRepository.Create(newDailySession);
                        await AddDefualtAttendencToDailySession(newDailySession.Id);
                    }
                    else
                    {
                        await dailySessions_RecordRepository.Update(new DailySessions_Record()
                        {
                            Date = item.Date,
                            Id = item.DailySessionId.Value,
                            Sessions_RecordId = item.Sessions_RecordId,
                            Subject_Title = item.Subject_Title                           
                        });
                    }
                }
                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Daily Sessions Added Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> GetAllDailySessions(Guid divissionId)
        {
            var Data = new GetAllDailySessionsResponse();
            GeneralResponse response;
            try
            {
                var DailySessions = dailySessions_RecordRepository.GetAll()                    
                    .Include(s => s.Sessions_Record)                    
                    .Include(h => h.Sessions_Record.Hall)
                    .Include(s => s.Sessions_Record.Subject)
                    .Include(c => c.Sessions_Record.Class)
                    .Where(s => s.Sessions_Record.Division.Id == divissionId)
                    .ToList();
                foreach (var item in DailySessions)
                {
                    var Sessions_Record = DailySessions
                        .Find(c => c.Sessions_Record.Id == item.Sessions_Record.Id)
                        ?.Sessions_Record;
                    var Class = Sessions_Record?.Class;
                    var Hall = Sessions_Record?.Hall;
                    var Subject = Sessions_Record?.Subject;
                    Data.dailySessions_Records.Add(new DailySessions_RecordDto()
                    {
                        Id = item.Id,
                        Date = item.Date,
                        Subject_Title = item.Subject_Title,
                        Class = Class.Name,
                        Hall = Hall.Name,
                        SubjectName = Subject.Name,
                        Day = Sessions_Record.day.ToString(),
                    });
                }
                if (Data.dailySessions_Records.Count != 0)
                {
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Daily Sessions Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Daily Sessions Found !!";
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

        public async Task<GeneralResponse> GetAllDailySessionsByDate(GetAllDailySessionsByDateRequste requste)
        {            
            var Data = new GetAllDailySessionsByDateResponse();
            GeneralResponse response;
            try
            {
                var DailySessions = dailySessions_RecordRepository.GetAll()
                    .Include(s => s.Sessions_Record)
                    .Include(h => h.Sessions_Record.Hall)
                    .Include(s => s.Sessions_Record.Subject)
                    .Include(c => c.Sessions_Record.Class)
                    .Where(s => s.Sessions_Record.Division.Id == requste.DivisionId
                             && s.Date.Date == requste.Date.Date)
                    .ToList();
                foreach (var item in DailySessions)
                {
                    var Sessions_Record = DailySessions
                        .Find(c => c.Sessions_Record.Id == item.Sessions_Record.Id)
                        ?.Sessions_Record;
                    var Class = Sessions_Record?.Class;
                    var Hall = Sessions_Record?.Hall;
                    var Subject = Sessions_Record?.Subject;
                    Data.dailySessions_Records.Add(new DailySessions_RecordDto()
                    {
                        Id = item.Id,
                        Date = item.Date,
                        Subject_Title = item.Subject_Title,
                        Class = Class.Name,
                        Hall = Hall.Name,
                        SubjectName = Subject.Name,
                        Day = Sessions_Record.day.ToString(),
                        Sessions_RecordId = item.Sessions_RecordId
                    });
                }
                if (Data.dailySessions_Records.Count != 0)
                {
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Daily Sessions Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Daily Sessions Found !!";
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
