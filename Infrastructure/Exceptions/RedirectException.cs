using Microsoft.AspNetCore.Mvc;

namespace Winterra.Infrastructure.Exceptions
{
    public class RedirectException : Exception
    {
        public string RedirectUrl { get; }

        public RedirectException(string redirectUrl)
        {
            RedirectUrl = redirectUrl ?? throw new ArgumentNullException(nameof(redirectUrl));
        }

        public RedirectException(IActionResult result)
        {
            if (result is RedirectResult redirectResult)
            {
                RedirectUrl = redirectResult.Url!;
            }
            else if (result is RedirectToActionResult redirectToActionResult)
            {
                // Build the redirect URL from action/controller
                var url = $"/{redirectToActionResult.ControllerName}/{redirectToActionResult.ActionName}";
                if (redirectToActionResult.RouteValues is { Count: > 0 })
                {
                    var query = string.Join("&", redirectToActionResult.RouteValues.Select(kv => $"{kv.Key}={kv.Value}"));
                    url += $"?{query}";
                }
                RedirectUrl = url;
            }
            else
            {
                throw new ArgumentException("Only RedirectResult or RedirectToActionResult are supported.", nameof(result));
            }
        }
    }
}
