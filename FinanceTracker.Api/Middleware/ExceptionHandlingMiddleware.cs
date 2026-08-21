using System.Text.Json;

namespace FinanceTracker.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (statusCode,title) = exception switch
            {
                ArgumentException => (StatusCodes.Status400BadRequest, "Invalid Request"),
                KeyNotFoundException => (StatusCodes.Status404NotFound, "Resource not Found"),
                InvalidOperationException => (StatusCodes.Status409Conflict, exception.Message),
                UnauthorizedAccessException => (StatusCodes.Status403Forbidden, "Access denied"),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
            };

            var problem = new
            {
                Status = statusCode,
                Title = title,
                traceid = context.TraceIdentifier
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }
}
