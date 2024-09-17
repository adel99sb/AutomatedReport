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
    public class HallService : IHallService<GeneralResponse>
    {
        private readonly IUnitOfWork<Hall> hallRepository;
        public  HallService(IUnitOfWork<Hall> hallRepository)
        {
            this.hallRepository = hallRepository;
        }
        public async Task<GeneralResponse> AddHall(AddHallRequste requste)
        {
            GeneralResponse response;
            try
            {
                await hallRepository.Create(new Hall()
                {
                    Name = requste.name
                });

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Hall Added Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> DeleteHall(Guid id)
        {
            GeneralResponse response;
            try
            {
                await hallRepository.Delete(id);

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.Accepted;
                response.Message = "Hall Deleted Succesfully";
            }
            catch (Exception ex)
            {

                response = new GeneralResponse(null);
                response.StatusCode = Requests_Status.BadRequest;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GeneralResponse> EditeHall(EditeHallRequste requste)
        {
            GeneralResponse response;
            try
            {
                var hall = await hallRepository.GetById(requste.id);
                if (hall is not null)
                {
                    await hallRepository.Update(new Hall()
                    {
                        Id = requste.id,
                        Name = requste.name
                    });

                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.Accepted;
                    response.Message = "Hall Updated Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "Hall Not Found !!";
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

        public async Task<GeneralResponse> GetAllHalls()
        {
            var Data = new GetAllHallsResponse();
            GeneralResponse response;
            try
            {
                var Halles = hallRepository.GetAll();
                if (Halles.Count() != 0)
                {
                    foreach (var item in Halles)
                    {
                        Data.halls.Add(new HallDto()
                        {
                            id = item.Id,
                            Name = item.Name
                        });
                    }
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Halles Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Halles Found !!";
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

        public async Task<GeneralResponse> GetHallById(Guid id)
        {
            var Data = new GetHallByIdResponse();
            GeneralResponse response;
            try
            {
                var hall = await hallRepository.GetById(id);
                if (hall is not null)
                {
                    Data.hall = new HallDto()
                    {
                        id = hall.Id,
                        Name = hall.Name
                    };
                    response = new GeneralResponse(Data);
                    response.StatusCode = Requests_Status.Ok;
                    response.Message = "Get Hall Succesfully";
                }
                else
                {
                    response = new GeneralResponse(null);
                    response.StatusCode = Requests_Status.NotFound;
                    response.Message = "No Hall Found !!";
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
