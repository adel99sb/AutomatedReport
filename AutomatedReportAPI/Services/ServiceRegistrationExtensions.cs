using AutomatedReportAPI.AppData.Models;
using AutomatedReportAPI.Controllers.AdminDashboard;
using AutomatedReportAPI.Infrastructure;
using AutomatedReportAPI.Services.BackgroundJobs;
using AutomatedReportAPI.Services.EntityServices.Contracts;
using AutomatedReportAPI.Services.EntityServices.Service;
using AutomatedReportCore.Responces;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedReportAPI.Services
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
            .AddScoped(typeof(IUnitOfWork<Advertisement>), typeof(UnitOfWork<Advertisement>))
            .AddScoped(typeof(IUnitOfWork<Attendance>), typeof(UnitOfWork<Attendance>))
            .AddScoped(typeof(IUnitOfWork<_Class>), typeof(UnitOfWork<_Class>))
            .AddScoped(typeof(IUnitOfWork<Payment>), typeof(UnitOfWork<Payment>))
            .AddScoped(typeof(IUnitOfWork<Score>), typeof(UnitOfWork<Score>))
            .AddScoped(typeof(IUnitOfWork<Sessions_Record>), typeof(UnitOfWork<Sessions_Record>))
            .AddScoped(typeof(IUnitOfWork<Student>), typeof(UnitOfWork<Student>))
            .AddScoped(typeof(IUnitOfWork<Subject>), typeof(UnitOfWork<Subject>))
            .AddScoped(typeof(IUnitOfWork<Teacher>), typeof(UnitOfWork<Teacher>))
            .AddScoped(typeof(IUnitOfWork<Test>), typeof(UnitOfWork<Test>))
            .AddScoped(typeof(IUnitOfWork<Test_Mark>), typeof(UnitOfWork<Test_Mark>))
            .AddScoped(typeof(IUnitOfWork<Division>), typeof(UnitOfWork<Division>))
            .AddScoped(typeof(IUnitOfWork<Hall>), typeof(UnitOfWork<Hall>))
            .AddScoped(typeof(IUnitOfWork<User>), typeof(UnitOfWork<User>))
            .AddScoped(typeof(IUnitOfWork<DailySessions_Record>), typeof(UnitOfWork<DailySessions_Record>))
            .AddScoped(typeof(IUnitOfWork<Certificate>), typeof(UnitOfWork<Certificate>))
            .AddScoped(typeof(IUnitOfWork<GratitudeStudent>), typeof(UnitOfWork<GratitudeStudent>));
        }
        public static IServiceCollection AddBackgourndJob(this IServiceCollection services)
        {
            return services
                .AddScoped<IBackgourndJobService, BackgourndJobService>();
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IUserService<GeneralResponse>), typeof(UserService))
                .AddScoped(typeof(IUserService<IActionResult>), typeof(UserController))

                .AddScoped(typeof(ICertificateService<GeneralResponse>), typeof(CertificateService))
                .AddScoped(typeof(ICertificateService<IActionResult>), typeof(CertificateController))

                .AddScoped(typeof(ISubjectService<GeneralResponse>), typeof(SubjectService))
                .AddScoped(typeof(ISubjectService<IActionResult>), typeof(SubjectController))

                .AddScoped(typeof(IDivisionService<GeneralResponse>), typeof(DivisionService))
                .AddScoped(typeof(IDivisionService<IActionResult>), typeof(DivisionController))

                .AddScoped(typeof(IClassService<GeneralResponse>), typeof(ClassService))
                .AddScoped(typeof(IClassService<IActionResult>), typeof(ClassController))

                .AddScoped(typeof(IAttendanceService<GeneralResponse>), typeof(AttendanceService))
                .AddScoped(typeof(IAttendanceService<IActionResult>), typeof(AttendanceController))

                .AddScoped(typeof(IDailySessionsService<GeneralResponse>), typeof(DailySessionsService))
                .AddScoped(typeof(IDailySessionsService<IActionResult>), typeof(DailySessionsController))

                .AddScoped(typeof(IHallService<GeneralResponse>), typeof(HallService))
                .AddScoped(typeof(IHallService<IActionResult>), typeof(HallController))

                .AddScoped(typeof(IPaymentService<GeneralResponse>), typeof(PaymentService))
                .AddScoped(typeof(IPaymentService<IActionResult>), typeof(PaymentController))

                .AddScoped(typeof(ISessions_RecordService<GeneralResponse>), typeof(Sessions_RecordService))
                .AddScoped(typeof(ISessions_RecordService<IActionResult>), typeof(Sessions_RecordController))

                .AddScoped(typeof(IStudentService<GeneralResponse>), typeof(StudentService))
                .AddScoped(typeof(IStudentService<IActionResult>), typeof(StudentController))

                .AddScoped(typeof(ITeacherService<GeneralResponse>), typeof(TeacherService))
                .AddScoped(typeof(ITeacherService<IActionResult>), typeof(TeacherController))

                .AddScoped(typeof(ITestService<GeneralResponse>), typeof(TestService))
                .AddScoped(typeof(ITestService<IActionResult>), typeof(TestController))

                .AddScoped(typeof(ITestMarkService<GeneralResponse>), typeof(TestMarkService))
                .AddScoped(typeof(ITestMarkService<IActionResult>), typeof(Test_MarkController))
            
                .AddScoped(typeof(IGlobalService<GeneralResponse>), typeof(GlobalService))
                .AddScoped(typeof(IGlobalService<IActionResult>), typeof(GlobalController));
        }
    }
}