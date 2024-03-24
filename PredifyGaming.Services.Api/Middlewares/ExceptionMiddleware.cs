using PredifyGaming.Domain;
using FluentValidation;
using System.Net;
using Newtonsoft.Json;


namespace PredifyGaming.Services.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (DomainException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch(ValidationException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var message = string.Empty;

            switch (exception)
            {
                case DomainException:
                    context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    message = exception.Message;
                    break;

                case ValidationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    message = JsonConvert.SerializeObject(((ValidationException)exception).Errors);
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    break;
            }

            await context.Response.WriteAsync(new ErrorDetailsModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }

    public class ErrorDetailsModel
    {
        public int StatusCode { get; set;}
        public string? Message { get; set;}
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
