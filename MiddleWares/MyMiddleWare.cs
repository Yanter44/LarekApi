using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

namespace LarekApi.MiddleWares
{
    public class MyMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MyMiddleWare> _logger;
        public MyMiddleWare( ILogger<MyMiddleWare> logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Передача управления следующему middleware
                await _next(context);
               _logger.LogInformation("MyMiddleware has processed the request.");
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                _logger.LogError(ex, "An error occurred during request processing.");
                // Возврат клиенту ошибки
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Internal Server Error");
            }

        }
    }
}
