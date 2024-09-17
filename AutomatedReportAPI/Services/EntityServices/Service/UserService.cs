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
    public class UserService : IUserService<GeneralResponse>
    {
        private readonly IUnitOfWork<User> userRepository;
        public UserService(IUnitOfWork<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<GeneralResponse> EditeUserPassword(EditeUserPasswordRequste request)
        {
            GeneralResponse response;
            try
            {
                var user = await userRepository.GetById(request.Id);
                if (user != null)
                {
                    user.Password = request.NewPassword;
                    await userRepository.Update(user);

                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.Accepted;
                    response.Message = "User Password Edited Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "User Not Found !!";
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

        public async Task<GeneralResponse> GetAllUsers()
        {
            var Data = new GetAllUsersResponse();
            GeneralResponse response;
            try
            {
                var users = userRepository.GetAll();
                foreach (var user in users)
                {
                    Data.users.Add(new UserDto()
                    {
                        Id = user.Id,
                        Type = user.Type
                    });
                }
                if (Data.users.Count != 0)
                {
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Users Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "NO Users Found !!";
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

        public async Task<GeneralResponse> Login(LoginRequste request)
        {
            var Data = new LoginResponse();
            GeneralResponse response;
            try
            {
                var users = userRepository.GetAll();
                foreach (var user in users)
                {
                    if (user.Id == request.Id && user.Password == request.Password)
                    {
                        Data.user.Id = user.Id;
                        Data.user.Type = user.Type;
                        break; // Exit the loop once a matching user is found
                    }
                }
                if (Data.user.Type != null)
                {
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Login Successfully";
                }
                else
                 {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "Check The User Name Or Password Then Try Again!!";
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
