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

            var accountDataAccess = httpContext.RequestServices.GetService<AccountDataAccess>();
            var loginUser = accountDataAccess?.GetLoginMemberData(email);

            if (loginUser?.Session == null || loginUser.Session != session)
            {
                Console.WriteLine("NOT AUTHENTICATED");
                context.Result = new RedirectToActionResult("Logout", "Account", null);
                return;
            }

            httpContext.Items["LoginUser"] = loginUser;
        }
        else
        {
            context.Result = new RedirectToActionResult("Logout", "Account", null);
        }
    }
}
