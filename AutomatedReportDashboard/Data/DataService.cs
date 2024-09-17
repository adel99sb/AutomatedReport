using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutomatedReportCore.Enums;
using AutomatedReportCore.Requstes.AdminDashboard;
using AutomatedReportCore.Responces;
using MauiApp1.Data;
using MauiApp1.Models;


namespace MauiApp1.Data
{
    public class DataService
    {
        HttpClient client = new HttpClient();
        string baseUrl;
        JsonSerializerOptions options;
        public DataService()
        {
            client = new HttpClient();
            baseUrl = "http://192.168.43.178:5000/";
            //baseUrl = "https://adel99.bsite.net/";
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        }
        #region User
        public async Task<GeneralResponse> GetAllUsers()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + "api/User/GetAllUsers");
                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();
                GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
                return Data;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
        public async Task<GeneralResponse> Login(Guid UserId, string Password)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/User/Login?Id={UserId}&Password={Password}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> EditePassword(string UserId, string Password)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + $"api/User/EditeUserPassword?Id={UserId}&NewPassword={Password}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        #endregion
        #region Student
        public async Task<GeneralResponse> GetAllStudentsByDivisionId(Guid? Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Student/GetAllStudentsByDivisionId?divisionId={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> GetAllStudents()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Student/GetAllStudentsWithDivision");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> GetStudentById(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Student/GetStudentById?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> MoveStudentToGratitude(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Student/MoveStudentToGratitude?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> EditeStudent(EditeStudentRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + "api/Student/EditeStudent");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> DeleteStudent(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, baseUrl + $"api/Student/DeleteStudent?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;

        }
        public async Task<GeneralResponse> AddStudent(AddStudentRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + "api/Student/AddStudent");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        #endregion
        #region Certificates
        public async Task<GeneralResponse> GetAllCertificates()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + "api/Certificate/GetAllCertificates");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        #endregion
        #region Hall
        public async Task<GeneralResponse> GetAllHalls()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + "api/Hall/GetAllHalls");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> EditeHall(EditeHallRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + "api/Hall/EditeHall");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> AddHall(AddHallRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + "api/Hall/AddHall");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> GetHallById(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Hall/GetHallById?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> DeleteHall(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, baseUrl + $"api/Hall/DeleteHall?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;

        }
        #endregion
        #region Test
        public async Task<GeneralResponse> GetAllTests(Guid? Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Test/GetAllTests?divisionId={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> EditeTest(EditeTestRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + "api/Test/EditeTest");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> MarkTestAsDone(Guid testId)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + $"api/Test/MarkAsDone?id={testId}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> AddTest(AddTestRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + "api/Test/AddTest");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> GetTestById(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Test/GetTestById?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> DeleteTest(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, baseUrl + $"api/Test/DeleteTest?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;

        }
        #endregion
        #region TestMarks
        public async Task<GeneralResponse> GetAllTestMarks(Guid? Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Test_Mark/GetAllTestMarks?testId={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> EditeTestMarks(EditeTestMarksRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + "api/Test_Mark/UpdateTestMarks");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
    
        #endregion
        #region Teacher
        public async Task<GeneralResponse> GetAllTeachers()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + "api/Teacher/GetAllTeachers");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> AddTeacher(AddTeacherRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + "api/Teacher/AddTeacher");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> EditeTeacher(EditeTeacherRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + "api/Teacher/EditeTeacher");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> GetTeacherById(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Teacher/GetTeacherById?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> DeleteTeacher(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, baseUrl + $"api/Teacher/DeleteTeacher?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;

        }
        #endregion
        #region Class
        public async Task<GeneralResponse> GetAllClasses()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + "api/Class/GetAllClasses");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> EditeClass(EditeClassRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + "api/Class/EditeClass");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> AddClass(AddClassRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + "api/Class/AddClass");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> GetClassById(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Class/GetClassById?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> DeleteClass(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, baseUrl + $"api/Class/DeleteClass?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;

        }
        #endregion
        #region Division
        public async Task<GeneralResponse> GetDivisionById(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Division/GetDivisionById?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> GetAllDivisionsWithStudentsNomber(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Division/GetAllDivisionsWithStudentsNomber?certificateId={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> AddDivision(AddDivisionRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + "api/Division/AddDivision");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> GetAllDivisions(Guid? Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Division/GetAllDivisions?certificateId={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> EditeDivision(EditeDivisionRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + "api/Division/EditeDivision");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> DeleteDivision(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, baseUrl + $"api/Division/DeleteDivision?id={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;

        }
        #endregion
        #region Payments
        public async Task<GeneralResponse> GetAllPayments(Guid Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Payment/GetAllPayments?studentId={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        public async Task<GeneralResponse> AddPayment(AddPaymentRequste requsteData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + "api/Payment/AddPayment");
            var DataRequste = JsonSerializer.Serialize(requsteData);
            var content = new StringContent(DataRequste, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        #endregion
        #region Subjects
        public async Task<GeneralResponse> GetAllSubjects(Guid? Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Subject/GetAllSubjects?divisionId={Id}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse Data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return Data;
        }
        #endregion
        #region Sessioin_Record
        public async Task<GeneralResponse> GetAllSessionsGroupedByDays(Guid divisionId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Sessions_Record/GetAllSessionsGroupedByDays?divisionId={divisionId}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }
        public async Task<GeneralResponse> GetAllSessionsByDay(Guid divisionId,string day)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Sessions_Record/GetAllSessionsByDay?divisionId={divisionId}&Day={day}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }

        public async Task<GeneralResponse> GetAllSessions(Guid divisionId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Sessions_Record/GetAllSessions?divisionId={divisionId}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            // Check if the result is empty
            if (string.IsNullOrWhiteSpace(result))
            {
                // Return an empty or default GeneralResponse
                return new GeneralResponse(divisionId)
                {
                    StatusCode = Requests_Status.NotFound, // or any appropriate status code
                };
            }

            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }

        public async Task<GeneralResponse> AddSession(AddSessionRequste1 requestData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + $"api/Sessions_Record/AddSession");
            var dataRequest = JsonSerializer.Serialize(requestData);
            var content = new StringContent(dataRequest, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }

        public async Task<GeneralResponse> EditSession(EditeSessionRequste requestData)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + $"api/Sessions_Record/EditeSession");
            var dataRequest = JsonSerializer.Serialize(requestData);
            var content = new StringContent(dataRequest, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }

        public async Task<GeneralResponse> DeleteSession(Guid sessionId)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, baseUrl + $"api/Sessions_Record/DeleteSession?id={sessionId}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }

        #endregion
        #region Daily_Sessioins
        public async Task<GeneralResponse> GetAllDailySessionsByDate(Guid divisionId,string dateTime)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/DailySessions/GetAllDailySessionsByDate?divisionId={divisionId}&Date={dateTime}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }

        public async Task<GeneralResponse> GetAllDailySessions(Guid divisionId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/DailySessions/GetAllDailySessions?divissionId={divisionId}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            // Check if the result is empty
            if (string.IsNullOrWhiteSpace(result))
            {
                // Return an empty or default GeneralResponse
                return new GeneralResponse(divisionId)
                {
                    StatusCode = Requests_Status.NotFound, // or any appropriate status code
                };
            }

            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }

        public async Task<GeneralResponse> AddDailySession(AddDailySessionsRequste requestData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + $"api/DailySessions/AddDailySessions");
            var dataRequest = JsonSerializer.Serialize(requestData);
            var content = new StringContent(dataRequest, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }
        #endregion
        #region Atendence
        public async Task<GeneralResponse> GetAllAttendanceByDate(Guid divisionId, string dateTime)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Attendance/GetAttendanceByDate?divisionId={divisionId}&Date={dateTime}");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }

        public async Task<GeneralResponse> UpdateAttendace(EditeAttendanceRequste requestData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + $"api/Attendance/EditeAttendance");
            var dataRequest = JsonSerializer.Serialize(requestData);
            var content = new StringContent(dataRequest, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }
        #endregion
        #region Global
        public async Task<GeneralResponse> GetAllPhoneNumbers()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Global/GetAllPhoneNumbers");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }
        public async Task<GeneralResponse> GetAllHappyBirthDays()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Global/GetTodayBirthDayNumbers");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }
        public async Task<GeneralResponse> GetAllStatistics()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"api/Global/GetAllStatistics");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            GeneralResponse data = JsonSerializer.Deserialize<GeneralResponse>(result, options);
            return data;
        }
        #endregion



    }
}