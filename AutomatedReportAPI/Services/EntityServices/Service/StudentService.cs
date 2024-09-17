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
    public class StudentService : IStudentService<GeneralResponse>
    {
        private readonly IUnitOfWork<Student> studentRepository;
        private readonly IUnitOfWork<Test_Mark> testMarkRepository;
        private readonly IUnitOfWork<Division> divisionMarkRepository;
        private readonly IUnitOfWork<GratitudeStudent> GratitudeStudentRepository;
        public StudentService(IUnitOfWork<Student> studentRepository,
            IUnitOfWork<Test_Mark> testMarkRepository,
            IUnitOfWork<Division> divisionMarkRepository,
            IUnitOfWork<GratitudeStudent> gratitudeStudentRepository)
        {
            this.studentRepository = studentRepository;
            this.testMarkRepository = testMarkRepository;
            this.divisionMarkRepository = divisionMarkRepository;
            GratitudeStudentRepository = gratitudeStudentRepository;
        }

        public async Task<GeneralResponse> AddStudent(AddStudentRequste requste)
        {
            GeneralResponse response;
            try
            {
                var divison = divisionMarkRepository.GetAll()                    
                    .Where(d => d.Id == requste.divisionId)
                    ?.FirstOrDefault();
                await studentRepository.Create(new Student()
                {
                    First_Name = requste.first_Name,
                    Last_Name = requste.last_Name,
                    Address = requste.address,
                    BirthDay = requste.birthDay,
                    Gender = requste.gender,
                    Father_Name = requste.father_Name,
                    Father_Phone = requste.father_Phone,
                    Mother_Name = requste.mother_Name,
                    Mother_Phone = requste.mother_Phone,
                    DefaultParentPhonIsFather = requste.defaultParentPhonIsFather,
                    Phone = requste.phone,
                    Total_Payments = requste.total_Payments,
                    agreedMonthlyPayment = requste.agreedMonthlyPayment,
                    DivisionId = requste.divisionId
                });

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Student Added Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> DeleteStudent(Guid id)
        {
            GeneralResponse response;
            try
            {
                await studentRepository.Delete(id);

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Student Deleted Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> EditeStudent(EditeStudentRequste requste)
        {
            GeneralResponse response;
            try
            {
                var divison = studentRepository.GetAll()
                    .Include(d => d.Division)
                    .Where(d => d.Division.Id == requste.divisionId)
                    .FirstOrDefault()?.Division;
                await studentRepository.Update(new Student()
                {
                    Id = requste.id,
                    First_Name = requste.first_Name,
                    Last_Name = requste.last_Name,
                    Address = requste.address,
                    BirthDay = requste.birthDay,
                    Gender = requste.gender,
                    Father_Name = requste.father_Name,
                    Father_Phone = requste.father_Phone,
                    Mother_Name = requste.mother_Name,
                    Mother_Phone = requste.mother_Phone,
                    DefaultParentPhonIsFather = requste.defaultParentPhonIsFather,
                    Phone = requste.phone,
                    Total_Payments = requste.total_Payments,
                    agreedMonthlyPayment = requste.agreedMonthlyPayment,
                    Division = divison
                });

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Student Updated Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> GetAllStudentsByDivisionId(Guid divisionId)
        {
            var Data = new GetAllStudentsByDivisionIdResponse();
            GeneralResponse response;
            try
            {
                var Students = studentRepository.GetAll()
                    .Include(d => d.Division)
                    .Where(d => d.Division.Id == divisionId);
                foreach (var item in Students)
                {
                    Data.students.Add(new StudentAttendanceDto()
                    {
                        Id = item.Id,
                        First_Name = item.First_Name,
                        Last_Name = item.Last_Name
                    });
                }
                if (Data.students.Count != 0)
                {
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Students Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Students Found !!";
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

        public async Task<GeneralResponse> GetAllStudentsByTestId(Guid testId)
        {
            var Data = new GetAllStudentsByTestIdResponse();
            GeneralResponse response;
            try
            {
                var StudentsId = testMarkRepository.GetAll()
                    .Include(t => t.Test)
                    .Include(s => s.Student)
                    .Where(t => t.Test.Id == testId)
                    .Select(s => s.Student.Id).ToList();
                    Data.studebtsIds.AddRange(StudentsId);
                if (Data.studebtsIds.Count != 0)
                {
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Students Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Students Found !!";
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

        public async Task<GeneralResponse> GetAllStudentsWithDivision()
        {
            var Data = new GetAllStudentsWithDivisionResponse();
            GeneralResponse response;
            try
            {
                var Students = studentRepository.GetAll()
                    .Include(d => d.Division).ToList();

                foreach (var item in Students)
                {
                    var avg = await CalculateAvg(item.Id);
                    Data.students.Add(new StudentDto()
                    {
                        Id = item.Id,
                        First_Name = item.First_Name,
                        Last_Name = item.Last_Name,
                        Address = item.Address,
                        BirthDay = item.BirthDay,
                        Gender = item.Gender,
                        Father_Name = item.Father_Name,
                        Father_Phone = item.Father_Phone,
                        Mother_Name = item.Mother_Name,
                        Mother_Phone = item.Mother_Phone,
                        DefaultParentPhonIsFather = item.DefaultParentPhonIsFather,
                        Phone = item.Phone,
                        Total_Payments = item.Total_Payments,
                        agreedMonthlyPayment = item.agreedMonthlyPayment,
                        Division = item.Division.Name,
                        Avg = avg
                    });
                }
                if (Data.students.Count != 0)
                {
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Students Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Students Found !!";
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
        private async Task<double> CalculateAvg(Guid id)
        {
            double Avg;
            var studentMarks = testMarkRepository.GetAll()
                    .Include(t => t.Test)
                    .Where(m => m.Test.IsDone && m.StudentId == id)
                    .ToList();
            var count = studentMarks.Count();
            double sum = 0;
            foreach (var m in studentMarks)
            {
                var mark = (m.Mark * 100) / m.Test.TotalMark;
                sum += mark;
            }
            Avg = count == 0 ? 0 : sum / count;
            return Avg;
        }
        public async Task<GeneralResponse> GetStudentById(Guid id)
        {
            var Data = new GetStudentByIdResponse();
            GeneralResponse response;
            try
            {
                var Student = studentRepository.GetAll()
                    .Include(d => d.Division)
                    .Where(s => s.Id == id).FirstOrDefault();
                var avg = await CalculateAvg(Student.Id);
                Data.student =  new StudentDto()
                    {
                        Id = Student.Id,
                        First_Name = Student.First_Name,
                        Last_Name = Student.Last_Name,
                        Address = Student.Address,
                        BirthDay = Student.BirthDay,
                        Gender = Student.Gender,
                        Father_Name = Student.Father_Name,
                        Father_Phone = Student.Father_Phone,
                        Mother_Name = Student.Mother_Name,
                        Mother_Phone = Student.Mother_Phone,
                        DefaultParentPhonIsFather = Student.DefaultParentPhonIsFather,
                        Phone = Student.Phone,
                        Total_Payments = Student.Total_Payments,
                        agreedMonthlyPayment = Student.agreedMonthlyPayment,
                        Division = Student.Division.Name,
                        Avg = avg
                    };
                
                if (Student is not null)
                {
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Student Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Students Found !!";
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

        public async Task<GeneralResponse> MoveStudentToGratitude(Guid id)
        {
            GeneralResponse response;
            try
            {

                var student = await studentRepository.GetById(id);
                var avg = await CalculateAvg(id);
                await GratitudeStudentRepository.Create(new GratitudeStudent()
                {
                    Address = student.Address,
                    agreedMonthlyPayment = student.agreedMonthlyPayment,
                    BirthDay = student.BirthDay,
                    DefaultParentPhonIsFather = student.DefaultParentPhonIsFather,
                    Father_Name = student.Father_Name,
                    Father_Phone = student.Father_Phone,
                    First_Name = student.First_Name,
                    Gender = student.Gender,
                    Last_Name = student.Last_Name,
                    Mother_Name = student.Mother_Name,
                    Mother_Phone = student.Mother_Phone,
                    Phone = student.Mother_Phone,
                    Total_Payments = student.Total_Payments,
                    Avg = avg
                });

                await studentRepository.Delete(id);

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Student Move to Gratitude Succesfully";        
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
