using System.Net;
using Azure;
using MeetUp.Persistence.UtilitiesConcrete;
using MeetUp.WebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MeetUp.WebAPI.Middlewares.CustomExceptionMiddlewares
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
            catch (Exception ex)
            {
                
                await HandleExceptionAsync(httpContext,ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
            };
            context.Response.ContentType = "application/json";
            var StatusCode = HttpStatusCode.InternalServerError;
            string message = exception.Message;
            var result = JsonConvert.SerializeObject(new Result(StatusCode,message, exception), settings);
            await context.Response.WriteAsync(result);
        }
    }
}
