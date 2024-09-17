using AutomatedReportCore.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AutomatedReportAPI.Services
{
    public static class HelperServices
    {        
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            List<string> errors = new();

            foreach (var modelStateValue in modelState.Values)
            {
                foreach (var modelError in modelStateValue.Errors)
                {
                    errors.Add(modelError.ErrorMessage);
                }
            }

            return errors;
        }
        public static IActionResult ToActionResult(this Requests_Status status,object value)
        {            
            return status switch
            {
                Requests_Status.Ok => new OkObjectResult(value),
                Requests_Status.Accepted => new OkObjectResult(value),
                Requests_Status.BadRequest => new BadRequestObjectResult(value),
                Requests_Status.NotFound => new NotFoundObjectResult(value),
                Requests_Status.Unauthorized => new UnauthorizedObjectResult(value),
                _ =>  new BadRequestObjectResult(value),
            };
        }
    }
}
