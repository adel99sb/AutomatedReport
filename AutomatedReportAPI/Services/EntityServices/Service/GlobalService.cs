using AutomatedReportAPI.AppData.Models;
using AutomatedReportAPI.Infrastructure;
using AutomatedReportAPI.Services.EntityServices.Contracts;
using AutomatedReportCore.Enums;
using AutomatedReportCore.Responces;
using AutomatedReportCore.Responces.AdminDashboard;
using AutomatedReportCore.Responces.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Xml.Linq;

namespace AutomatedReportAPI.Services.EntityServices.Service
{
    public class GlobalService : IGlobalService<GeneralResponse>
    {
        private readonly IUnitOfWork<Student> _studentService;
        private readonly IUnitOfWork<Hall> _hallService;
        private readonly IUnitOfWork<Division> _divisionService;
        private readonly IUnitOfWork<Teacher> _teacherService;
        private readonly IUnitOfWork<GratitudeStudent> _gratitudeStudentService;
        public GlobalService(
            IUnitOfWork<Student> studentService,
            IUnitOfWork<Hall> hallService,
            IUnitOfWork<Division> divisionService,
            IUnitOfWork<Teacher> teacherService,
            IUnitOfWork<GratitudeStudent> gratitudeStudent
            )
        {
            _studentService = studentService;
            _hallService = hallService;
            _divisionService = divisionService;
            _teacherService = teacherService;
            _gratitudeStudentService = gratitudeStudent;
        }

        public async Task<GeneralResponse> GetAllPhoneNumbers()
        {
            var Data = new GetAllPhoneNumbersResponse();
            GeneralResponse response;
            try
            {
                var phonNumbers = new List<string>();
                var teachers = _teacherService.GetAll()
                    .Select(t => t.Phone);
                var students = _studentService.GetAll()
                    .Select(s => s.Phone);
                var gratitudeStudent = _gratitudeStudentService.GetAll()
                    .Select(s => s.Phone);
                var studentsFathers = _studentService.GetAll()                    
                    .Select(p => p.Father_Phone);
                var studentsMothers = _studentService.GetAll()
                    .Select(p => p.Mother_Phone);

                foreach (var item in teachers)
                {
                    phonNumbers.Add(item);
                }
                foreach (var item in gratitudeStudent)
                {
                    phonNumbers.Add(item);
                }
                foreach (var item in students)
                {
                    phonNumbers.Add(item);
                }
                foreach (var item in studentsFathers)
                {
                    phonNumbers.Add(item);
                }
                foreach (var item in studentsMothers)
                {
                    phonNumbers.Add(item);
                }

                Data.PhoneNumbers.AddRange(phonNumbers);

                response = new GeneralResponse(Data);
                response.StatusCode = Requests_Status.Ok;
                response.Message = "Get All Phone Numbers Succesfully";

            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> GetAllStatistics()
        {
            var Data = new GetAllStatisticsResponse();
            GeneralResponse response;
            try
            {
                var MailNumber = _studentService.GetAll()
                    .Where(s => s.Gender == "ذكر")
                    .Count();

                var FemailNumber = _studentService.GetAll()
                    .Where(s => s.Gender == "أنثى")
                    .Count();

                var basicCertificateNumber = _studentService.GetAll()
                    .Include(d => d.Division)
                    .ThenInclude(c => c.Certificate)
                    .Where(s => s.Division.Certificate.Name
                                == "الشهادة الإعدادية")
                    .Count();

                var scientificCertificateNumber = _studentService.GetAll()
                    .Include(d => d.Division)
                    .ThenInclude(c => c.Certificate)
                    .Where(s => s.Division.Certificate.Name
                                == "الشهادة الثانوية - علمي")
                    .Count();

                var literaryCertificateNumber = _studentService.GetAll()
                    .Include(d => d.Division)
                    .ThenInclude(c => c.Certificate)
                    .Where(s => s.Division.Certificate.Name
                                == "الشهادة الثانوية - أدبي")
                    .Count();

                var Divisons = _divisionService.GetAll()
                    .Count();

                var basicCertificateDivisionNumber = _divisionService.GetAll()
                    .Include(c => c.Certificate)
                    .Where(s => s.Certificate.Name
                                == "الشهادة الإعدادية")
                    .Count();

                var literaryCertificateDivisionNumber = _divisionService.GetAll()
                    .Include(c => c.Certificate)
                    .Where(s => s.Certificate.Name
                                == "الشهادة الثانوية - أدبي")
                    .Count();

                var scientificCertificateDivisionNumber = _divisionService.GetAll()
                    .Include(c => c.Certificate)
                    .Where(s => s.Certificate.Name
                                == "الشهادة الثانوية - علمي")
                    .Count();

                var Teachers = _teacherService.GetAll().Count();

                var Halls = _hallService.GetAll().Count();

                var GratitudeStudent = _gratitudeStudentService.GetAll().Count();

                Data = new GetAllStatisticsResponse()
                {
                    MailNumber = MailNumber,
                    FemailNumber = FemailNumber,
                    basicCertificateNumber = basicCertificateNumber,
                    scientificCertificateNumber = scientificCertificateNumber,
                    literaryCertificateNumber = literaryCertificateNumber,
                    basicCertificateDivisionNumber = basicCertificateDivisionNumber,
                    literaryCertificateDivisionNumber = literaryCertificateDivisionNumber,
                    scientificCertificateDivisionNumber = scientificCertificateDivisionNumber,
                    DivisonNumber = Divisons,
                    HallNumber = Halls,
                    TeacherNumber = Teachers,
                    GratitudeStudentNumber = GratitudeStudent
                };
                response = new GeneralResponse(Data);
                response.StatusCode = Requests_Status.Ok;
                response.Message = "Get Statistics Succesfully";

            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> GetTodayBirthDayNumbers()
        {
            var Data = new GetTodayBirthDayNumbersResponse();
            GeneralResponse response;
            try
            {
                var BirthDayList = new List<BirthdayDto>();
                var students = _studentService.GetAll()
                    .Where(s => s.BirthDay.Date.Month == DateTime.Now.Date.Month
                                && s.BirthDay.Date.Day == DateTime.Now.Day);
                var gratitudeStudent = _gratitudeStudentService.GetAll()
                    .Where(s => s.BirthDay.Date.Month == DateTime.Now.Date.Month
                                && s.BirthDay.Date.Day == DateTime.Now.Day);
                foreach (var s in students)
                {
                    BirthDayList.Add(new BirthdayDto()
                    {
                        Name = $"{s.First_Name} {s.Last_Name}",
                        Phone = s.Phone
                    });
                }

                foreach (var gs in gratitudeStudent)
                {
                    BirthDayList.Add(new BirthdayDto()
                    {
                        Name = $"{gs.First_Name} {gs.Last_Name}",
                        Phone = gs.Phone
                    });
                }

                Data.Birthdays = BirthDayList;
                response = new GeneralResponse(Data);
                response.StatusCode = Requests_Status.Ok;
                response.Message = "Get Today BirthDays Numbers Succesfully";

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
