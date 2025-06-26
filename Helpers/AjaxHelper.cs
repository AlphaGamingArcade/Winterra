namespace Winterra.Helpers
{
    public class AjaxHelper
    {
        public static bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest" ||
                    request.Headers["Accept"].ToString().Contains("application/json");
        } 
    }
}