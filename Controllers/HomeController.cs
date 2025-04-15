using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Helpers;
using Winterra.Models.ViewModels;
using System.Diagnostics;
using System.Security.Claims;


namespace Winterra.Controllers
{
    public class HomeController : Controller
    {
		private readonly AccountDataAccess _accountDataAccess;
		private readonly ContentDataAccess _contentDataAccess;
		private readonly PreviewDataAccess _previewDataAccess;
        private readonly CharacterDataAccess _characterDataAccess;

		public HomeController(AccountDataAccess accountDataAccess, ContentDataAccess contentDataAccess, PreviewDataAccess previewDataAccess, CharacterDataAccess characterDataAccess)
        {
			this._accountDataAccess = accountDataAccess;
			this._contentDataAccess = contentDataAccess;
			this._previewDataAccess = previewDataAccess;
            this._characterDataAccess = characterDataAccess;
		}

        [Authorize(Roles = Roles.Admin)]
		public IActionResult Index(string? tab)
        {
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "user",
                MenuTitle = "Account Management",
                AccountCount = _accountDataAccess.GetAccountCount(),
                AccountList = _accountDataAccess.GetAccountList(),
                CharacterList = _characterDataAccess.GetCharacterList(),
				ContentList = _contentDataAccess.GetContentList(),
                PreviewList = _previewDataAccess.GetPreviewList(),
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [HttpGet("UsersPartial")]
        public IActionResult UsersPartial(){
            var users = this._accountDataAccess.GetAccountList();
            return PartialView("_AccountTable", users);
        }

        [HttpGet("AdministratorPartial")]
        public IActionResult AdministratorPartial(){
            var admins = this._accountDataAccess.GetAccountList();
            return PartialView("_AccountTable", admins);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
