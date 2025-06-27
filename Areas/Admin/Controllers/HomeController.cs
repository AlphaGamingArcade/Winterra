using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.Areas.Admin.Models.ViewModels;
using Winterra.DataContexts;
using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Controllers
{
    [Authorize]
    [ValidateSession]
    public class HomeController : BaseController
    {
        private readonly AccountDataAccess _accountDataAccess;
        private readonly ContentDataAccess _contentDataAccess;

        public HomeController(AccountDataAccess accountDataAccess, ContentDataAccess contentDataAccess)
        {
            _accountDataAccess = accountDataAccess;
            _contentDataAccess = contentDataAccess;
        }

        public IActionResult Index()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 1,
                MenuIn = "user",
                MenuTitle = "Account Management",
                UserAccountList = _accountDataAccess.GetAccountList(0),
                OnlinePlayerCount = _accountDataAccess.GetOnlinePlayerCount(),
                ActivePlayerCount = _accountDataAccess.GetPlayerCount(),
                InGameStellarCount = _accountDataAccess.GetInGameStellarCount(),
                LoginUserInfo = loginUser
            };

            return View(model);
        }


        public IActionResult Administrator()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 1,
                MenuIn = "administrator",
                MenuTitle = "Account Management",
                AdminAccountList = _accountDataAccess.GetAccountList(1),
                LoginUserInfo = loginUser
            };

            return View(model);
        }
    } 
}