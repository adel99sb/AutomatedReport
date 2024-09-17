using System.Net;

namespace AutomatedReportCore.Enums
{
    public enum Requests_Status
    {
        // Good Requests
        Ok = HttpStatusCode.OK, // (200)
        Accepted = HttpStatusCode.Accepted, // (202)
        // Bad Requests
        BadRequest = HttpStatusCode.BadRequest, // (400)
        Unauthorized = HttpStatusCode.Unauthorized, // (401)
        NotFound = HttpStatusCode.NotFound, // (404)
        // Unexpected Requests
        NotImplemented = HttpStatusCode.NotImplemented // (501)
    }
}
