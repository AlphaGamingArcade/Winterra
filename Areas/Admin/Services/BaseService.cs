using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Services
{
    public abstract class BaseService
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected Account? GetLoginUser()
        {
            var loginUser = _httpContextAccessor.HttpContext?.Items["LoginUser"] as Account;
            return loginUser;
        }

        // Add other common user-access methods as needed
    }
}