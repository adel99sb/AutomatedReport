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
    public class TestService : ITestService<GeneralResponse>
    {
        private readonly IUnitOfWork<Test> testRepository;
        private readonly IUnitOfWork<Division> divisionRepository;
        private readonly IUnitOfWork<Subject> subjectRepository;
        private readonly IStudentService<GeneralResponse> studentService;
        private readonly ITestMarkService<GeneralResponse> testMarkService;
        public TestService(IUnitOfWork<Test> testRepository,
            IUnitOfWork<Division> divisionRepository,
            ITestMarkService<GeneralResponse> testMarkService,
            IStudentService<GeneralResponse> studentService,
            IUnitOfWork<Subject> subjectRepository)
        {
            this.testRepository = testRepository;
            this.testMarkService = testMarkService;
            this.studentService = studentService;
            this.divisionRepository = divisionRepository;
            this.subjectRepository = subjectRepository;
        }

        public async Task<GeneralResponse> AddTest(AddTestRequste requste)
        {
            GeneralResponse response;
            try
            {
                var division = await divisionRepository.GetById(requste.DivisionId);
                var subject = await subjectRepository.GetById(requste.SubjectId);
                var test = new Test()
                {
                    DateTime = requste.DateTime,
                    Description = requste.Description,
                    TotalMark = requste.TotalMark,
                    DivisionId = division.Id,
                    SubjectId = subject.Id
                };
                await testRepository.Create(test);

                List <AutomatedReportCore.Requstes.DTOs.TestMarkDto> TestMarksList = new();
                var result = await studentService.GetAllStudentsByDivisionId(test.DivisionId);
                if (result.Data is GetAllStudentsByDivisionIdResponse studentList)
                {
                    foreach (var item in studentList.students)
                    {
                        TestMarksList.Add(new AutomatedReportCore.Requstes.DTOs.TestMarkDto
                        {
                            Mark = 0,
                            TestId = test.Id,
                            StudentId = item.Id
                        });
                    }
                }
                var res = await testMarkService.AddTestMarks(
                    new AddTestMarkRequste()
                    {
                        TestMarksList = TestMarksList
                    });
                if (res.StatusCode == Requests_Status.Accepted)
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.Accepted;
                    response.Message = "Test Added Succesfully";
                }                
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.BadRequest;
                    response.Message = "Some Thing Went Wrong";
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

        public async Task<GeneralResponse> DeleteTest(Guid id)
        {
            GeneralResponse response;
            try
            {
                await testRepository.Delete(id);

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Test Deleted Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> EditeTest(EditeTestRequste requste)
        {
            GeneralResponse response;
            try
            {
                var division = await divisionRepository.GetById(requste.DivisionId);
                var subject = await subjectRepository.GetById(requste.SubjectId);
                await testRepository.Update(new Test()
                {
                    Id = requste.Id,
                    DateTime = requste.DateTime,
                    Description = requste.Description,
                    IsDone = requste.IsDone,
                    TotalMark = requste.TotalMark,
                    DivisionId = division.Id,
                    SubjectId = subject.Id
                });

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Test Updated Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> GetAllTests(Guid divisionId)
        {
            var Data = new GetAllTestsResponse();
            GeneralResponse response;
            try
            {
                var Tests = testRepository.GetAll()
                    .Include(s => s.Subject);
                if (Tests.Count() != 0)
                {
                    foreach (var item in Tests)
                    {
                        Data.tests.Add(new TestDto()
                        {
                            Id = item.Id,
                            DateTime = item.DateTime,
                            Description = item.Description,
                            IsDone = item.IsDone,
                            TotalMark = item.TotalMark,
                            Subject = item.Subject.Name
                        });
                    }
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Tests Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Tests Found !!";
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

        public async Task<GeneralResponse> GetTestById(Guid id)
        {
            var Data = new GetTestByIdResponse();
            GeneralResponse response;
            try
            {
                var test = testRepository.GetAll()
                    .Include(s => s.Subject)
                    .Where(t => t.Id == id).FirstOrDefault();                    
                if (test is not null)
                {
                    Data.test = new TestDto()
                    {
                        Id = test.Id,
                        DateTime = test.DateTime,
                        Subject = test.Subject.Name,
                        Description = test.Description,
                        TotalMark = test.TotalMark,
                        IsDone = test.IsDone
                    };
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Test Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Test Found !!";
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

        public async Task<GeneralResponse> MarkAsDone(Guid id)
        {
            GeneralResponse response;
            try
            {            
                var Test = await testRepository.GetById(id);
                Test.IsDone = true;
                await testRepository.Update(Test);                                                

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Test Updated Succesfully";
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
