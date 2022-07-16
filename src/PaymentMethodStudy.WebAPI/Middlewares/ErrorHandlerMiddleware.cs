using Newtonsoft.Json;
using PaymentMethodStudy.Application.Exceptions;
using PaymentMethodStudy.Application.Responses;
using System.Net;

namespace PaymentMethodStudy.WebAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await ExceptionHandlerAsync(context, exception);
            }
        }

        private async Task ExceptionHandlerAsync(HttpContext context, Exception exception)
        {
            int httpCode;
            string message = exception.Message ?? "An exception was thrown.";

            switch (exception)
            {
                case CustomValidationException validationException:
                    httpCode = (int)HttpStatusCode.BadRequest;
                    //message = JsonConvert.SerializeObject(validationException.Failures);
                    message = String.Join(" ", validationException.Failures);
                    break;
                case CustomBadRequestException badRequestException:
                    httpCode = (int)HttpStatusCode.BadRequest;
                    message = badRequestException.Message;
                    break;
                case CustomNotFoundException notFoundException:
                    httpCode = (int)HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
                case CustomDatabaseException databaseException:
                    httpCode = (int)HttpStatusCode.InternalServerError;
                    message = databaseException.Message;
                    break;
                default:
                    httpCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError($"Following error occured: {exception.Message}");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = httpCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new FailResponse(message, httpCode)));
        }
    }
}
