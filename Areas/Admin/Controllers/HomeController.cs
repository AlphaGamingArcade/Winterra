using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.Areas.Admin.Services;

namespace Winterra.Areas.Admin.Controllers
{
    [Authorize]
    [ValidateSession]
    public class HomeController : BaseController
    {
        private readonly AccountService _accountService;

        public HomeController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            var model = _accountService.GetHomeIndexViewModel();
            return View(model);
        }


        public IActionResult Administrator()
        {
             var model = _accountService.GetHomeAdministratorViewModel();
            return View(model);
        }
    } 
}