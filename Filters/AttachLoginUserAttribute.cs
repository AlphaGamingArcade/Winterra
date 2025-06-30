using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using Winterra.DataContexts;

public class AttachLoginUserAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var httpContext = context.HttpContext;
        var user = httpContext.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            var email = user.FindFirst(ClaimTypes.Email)?.Value;
            var accountDataAccess = httpContext.RequestServices.GetService<AccountDataAccess>();
            var loginUser = accountDataAccess?.GetLoginMemberData(email);
            httpContext.Items["LoginUser"] = loginUser;
        }
    }
}
