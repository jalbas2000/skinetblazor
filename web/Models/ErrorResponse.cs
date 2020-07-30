using System.Collections.Generic;

namespace web.Models
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }

        public ErrorResponse(int statusCode, string message, string details, IEnumerable<string> errors)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
            Errors = errors;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}