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
    public class TestMarkService : ITestMarkService<GeneralResponse>
    {
        private readonly IUnitOfWork<Test_Mark> testMarkRepository;
        public TestMarkService(IUnitOfWork<Test_Mark> testMarkRepository)
        {
            this.testMarkRepository = testMarkRepository;
        }

        public async Task<GeneralResponse> AddTestMarks(AddTestMarkRequste requste)
        {            
            GeneralResponse response;
            try
            {
                //var testMarks = testMarkRepository.GetAll()
                //        .Include(s => s.Student)
                //        .Include(t => t.Test)
                //        .ToList();
                foreach (var item in requste.TestMarksList)
                {
                    //var student = testMarks.Find(s => s.Student.Id == item.StudentId)?
                    //    .Student;
                    //var test = testMarks.Find(t => t.Test.Id == item.TestId)?
                    //    .Test;
                    await testMarkRepository.Create(new Test_Mark()
                    {
                        Mark = item.Mark,
                        StudentId = item.StudentId,
                        TestId = item.TestId
                    });                    
                }
                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Test Marks Added Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> GetAllTestMarks(Guid testId)
        {
            var Data = new GetAllTestMarksResponse();
            GeneralResponse response;
            try
            {
                var testMarks = testMarkRepository.GetAll()
                        .Include(s => s.Student)
                        .Include(t => t.Test)
                        .ThenInclude(sb => sb.Subject)
                        .Where(t => t.Test.Id == testId)
                        .ToList();                
                if(testMarks.Count != 0)
                {
                    var test = testMarks.Find(t => t.Test.Id == testId)?
                    .Test;
                    foreach (var item in testMarks)
                    {
                        var student = testMarks.Find(s => s.Student.Id == item.Student.Id)?
                            .Student;
                        Data.testMarks.Add(new TestMarkDto()
                        {
                            Id = item.Id,
                            Mark = item.Mark,
                            Student_FirsName = student.First_Name,
                            Student_LastName = student.Last_Name,
                            StudentId = student.Id
                        });     
                    }
                    Data.Subject = test.Subject.Name;
                    Data.TotalMark = test.TotalMark;
                    Data.Date = test.DateTime;
                    Data.Description = test.Description;
                    Data.TestId = test.Id;

                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Test Marks Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Test Marks Found !!";
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

        public async Task<GeneralResponse> UpdateTestMarks(EditeTestMarksRequste requste)
        {            
            GeneralResponse response;
            try
            {
                var testMarks = testMarkRepository.GetAll()
                        .Include(s => s.Student)
                        .Include(t => t.Test)
                        .ToList();
                foreach (var item in requste.TestMarksList)
                {
                    var studentId = testMarks.Find(s => s.Student.Id == item.StudentId)?
                        .Student.Id;
                    var testId = testMarks.Find(t => t.Test.Id == item.TestId)?
                        .Test.Id;
                    var testMark = testMarks
                        .Find(s => s.Student.Id == studentId
                           && s.Test.Id == testId);
                    await testMarkRepository.Update(new Test_Mark()
                    {
                        Id = testMark.Id,
                        Mark = item.Mark,
                        Student = testMark.Student,
                        Test = testMark.Test
                    });
                }
                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Test Marks Updated Succesfully";
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
