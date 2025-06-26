using Winterra.Infrastructure.Exceptions;
using System.Net;
using Winterra.Helpers;

namespace Winterra.Infrastructure.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }
        
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Handle RedirectException first
            if (exception is RedirectException redirectEx)
            {
                if (AjaxHelper.IsAjaxRequest(context.Request))
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsJsonAsync(new
                    {
                        success = false,
                        status = (int)HttpStatusCode.Unauthorized,
                        message = "Please login to continue"
                    });
                    return;
                }

                context.Response.Redirect(redirectEx.RedirectUrl);
                return;
            }

            var (statusCode, errorMessage) = exception switch
            {
                NotFoundException => (HttpStatusCode.NotFound, exception.Message),
                UnauthorizedException => (HttpStatusCode.Unauthorized, exception.Message),
                ForbiddenException => (HttpStatusCode.Forbidden, exception.Message),
                ValidationException => (HttpStatusCode.BadRequest, exception.Message),
                BadRequestException => (HttpStatusCode.BadRequest, exception.Message),
                _ => (HttpStatusCode.InternalServerError,
                      _env.IsDevelopment() ? exception.Message : "An error occurred")
            };

            context.Response.StatusCode = (int)statusCode;

            if (AjaxHelper.IsAjaxRequest(context.Request))
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    success = false,
                    status = (int)statusCode,
                    message = errorMessage
                });
                return;
            }

            // Store exception for MVC error pages
            context.Items["OriginalPath"] = context.Request.Path;
            context.Items["Exception"] = exception;
            context.Items["ErrorMessage"] = errorMessage;

            string errorPath = statusCode switch
            {
                HttpStatusCode.NotFound => "/Error/Error404",
                HttpStatusCode.Unauthorized => "/Error/Error401",
                HttpStatusCode.Forbidden => "/Error/Error403",
                HttpStatusCode.BadRequest => "/Error/Error400",
                _ => "/Error/Error500"
            };

            Console.WriteLine("Hello");

            context.Response.Redirect(errorPath);
        }
    }
}