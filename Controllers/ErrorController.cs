using Microsoft.AspNetCore.Mvc;
using Winterra.Models.ViewModels;

namespace Winterra.Controllers
{
    [Route("Error")]
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("Error401")]
        public IActionResult Error401()
        {
            return CreateView(401, "Unauthorized Access");
        }

        [Route("Error403")]
        public IActionResult Error403()
        {
            return CreateView(403, "Access denied");
        }

        [Route("Error404")]
        public IActionResult Error404()
        {
            return CreateView(404, "Page Not Found");
        }

        [Route("Error400")]
        public IActionResult Error400()
        {
            return CreateView(400, "Bad Request");
        }

        [Route("Error500")]
        public IActionResult Error500()
        {
            return CreateView(500, "Internal Server Error");
        }

        private IActionResult CreateView(int statusCode, string menuTitle)
        {
            // Try to get message from multiple sources
            var errorMessage = GetErrorMessage();

            // Log for debugging
            _logger.LogInformation("Displaying error {StatusCode}: {Message}", statusCode, errorMessage);

            var model = new ErrorViewModel
            {
                StatusCode = statusCode
            };


            _logger.LogInformation($"Controller Error message {errorMessage}");

            return View($"Error{statusCode}", model);
        }

        private string GetErrorMessage()
        {
            // Check multiple sources for the error message
            if (HttpContext.Items.TryGetValue("ErrorMessage", out var itemMessage) && itemMessage is string)
                return (string)itemMessage;

            if (TempData.TryGetValue("ErrorMessage", out var tempMessage) && tempMessage is string)
                return (string)tempMessage;

            if (HttpContext.Items["Exception"] is Exception ex1)
                return ex1.Message;

            if (TempData["Exception"] is Exception ex2)
                return ex2.Message;

            return GetDefaultMessage(Response.StatusCode);
        }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                401 => "You are not authorized to access this resource",
                404 => "The requested page was not found",
                400 => "Your request contains invalid data",
                500 => "An unexpected error occurred on the server",
                _ => "An error occurred"
            };
        }
    }
}
