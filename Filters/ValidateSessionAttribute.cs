using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Winterra.DataContexts;

public class ValidateSessionAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var httpContext = context.HttpContext;
        var user = httpContext.User;


        if (user.Identity?.IsAuthenticated == true)
        {
            var email = user.FindFirst(ClaimTypes.Name)?.Value;
            var session = user.FindFirst(ClaimTypes.Hash)?.Value;

            Console.WriteLine("AUTHENTICATED");

            // Use DI to get the AccountDataAccess
            var accountDataAccess = httpContext.RequestServices.GetService<AccountDataAccess>();
            var loginUser = accountDataAccess?.GetLoginMemberData(email);

            if (loginUser?.Session == null || loginUser.Session != session)
            {
                context.Result = new RedirectToActionResult("Logout", "Account", null);
                return;
            }

            // ✅ Store the validated user object for later use in the controller/action
            httpContext.Items["LoginUser"] = loginUser;
        }
        else
        {
            Console.WriteLine("NOT AUTHENTICATED");
            // Not authenticated at all — redirect to logout/login
            context.Result = new RedirectToActionResult("Logout", "Account", null);
        }
    }
}
