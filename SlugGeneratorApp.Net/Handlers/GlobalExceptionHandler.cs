using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SlugGeneratorApp.Net.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unexpected error occurred: {Message}", exception.Message);
            _logger.LogError(exception, "TraceId: {TraceId}", httpContext.TraceIdentifier);

            var (statusCode, title) = exception switch
            {
                SlugGenerationException => ((int)HttpStatusCode.BadRequest, "Slug Generation Error"),
                _ => ((int)HttpStatusCode.InternalServerError, "Internal Server Error")
            };

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = "An unexpected error occurred. Our team has been notified.",
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode= statusCode;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}