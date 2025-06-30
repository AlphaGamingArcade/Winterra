using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.Helpers;

namespace Winterra.Areas.Admin.Controllers
{
    [Authorize(AuthenticationSchemes = "Auth")]
    public class UploadController : BaseController
    {
        private readonly IWebHostEnvironment _environment;

        public UploadController(
            IWebHostEnvironment environment
        )
        {
            _environment = environment;
        }

        [HttpPost]
        [Route("Upload/Attach/Image")]
        public async Task<IActionResult> UploadAttachImage(IFormFile upload)
        {
            if (upload == null || upload.Length == 0)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Invalid file"
                });
            }

            try
            {
                var fileName = FileNameHelper.GetUnixMicrotime() + Path.GetExtension(upload.FileName);

                // Define the subfolder under wwwroot
                var date = DateHelper.GetCurrentDateTime();
                var folderPath = Path.Combine("wwwroot", "uploads", "attach", "images", $"{date:yyyyMMdd}");

                // Create directory if it doesn't exist
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var savePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await upload.CopyToAsync(stream);
                }

                // Generate public URL
                var url = Url.Content($"~/uploads/attach/images/{date:yyyyMMdd}/{fileName}");

                return Json(new
                {
                    success = true,
                    url
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    error = "Upload failed: " + ex.Message
                });
            }
        }

        [HttpPost]
        [Route("Upload/Banner")]
        public async Task<IActionResult> UploadBanner(IFormFile upload)
        {
            if (upload == null || upload.Length == 0)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Invalid file"
                });
            }

            // Optional: Validate file extension
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            var extension = Path.GetExtension(upload.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Unsupported file format"
                });
            }

            try
            {
                // Generate filename
                var fileName = FileNameHelper.GetUnixMicrotime() + extension;

                // Get current date if needed (optional)
                var folderPath = Path.Combine(_environment.WebRootPath, "uploads", "banner");

                // Ensure directory exists
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                // Full path
                var savePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await upload.CopyToAsync(stream);
                }

                // Public-facing URL
                var url = Url.Content($"~/uploads/banner/{fileName}");

                return Ok(new
                {
                    success = true,
                    url
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    error = "Upload failed: " + ex.Message
                });
            }
        }
    }
}