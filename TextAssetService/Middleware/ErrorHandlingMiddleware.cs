using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TextAssetService.Exceptions;

namespace TextAssetService.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        static readonly ILogger _logger = Serilog.Log.ForContext<ErrorHandlingMiddleware>();

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IHostEnvironment env)
        {
            HttpStatusCode status;

            var errorResponseData = new ErrorResponseData()
            {
                Message = exception.Message,
                StackTrace = (!env.IsProduction()) ? exception.StackTrace : string.Empty
            };

            switch (exception)
            {
                case AmuNotFoundException _:
                    status = HttpStatusCode.NotFound;
                    break;
                case ArgumentException _:
                    status = HttpStatusCode.BadRequest;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    break;
            }

            errorResponseData.Status = status;

            var result = JsonSerializer.Serialize(errorResponseData);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
