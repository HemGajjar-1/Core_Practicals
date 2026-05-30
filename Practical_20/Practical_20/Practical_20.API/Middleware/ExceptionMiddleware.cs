using Practical_20.API.Models;
using System.Net;
using System.Text.Json;

namespace Practical_20.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context,ex);
            }
        }
        public static async Task HandleExceptionAsync(HttpContext context,Exception exception)
        {
            context.Response.ContentType = "applcation/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred",
                Details = exception.Message
            };
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
