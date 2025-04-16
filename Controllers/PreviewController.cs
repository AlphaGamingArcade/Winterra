using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Models.InputModels;
using Winterra.Models.ViewModels;
using System.Security.Claims;
using Winterra.Helpers;

namespace Winterra.Controllers
{
    public class PreviewController : Controller
    {
       	private readonly AccountDataAccess _accountDataAccess;
		private readonly ContentDataAccess _contentDataAccess;
		private readonly PreviewDataAccess _previewDataAccess;

		public PreviewController(AccountDataAccess accountDataAccess, ContentDataAccess contentDataAccess, PreviewDataAccess previewDataAccess)
        {
			this._accountDataAccess = accountDataAccess;
			this._contentDataAccess = contentDataAccess;
			this._previewDataAccess = previewDataAccess;
		}

        public IActionResult Characters()
        {
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

			var loginUser =  _accountDataAccess.GetLoginMemberData(accountEmail);

			if (loginUser?.Session == null || loginUser?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "characters",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};
			
			return View(model);
        }

        public IActionResult Highlights()
        {
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

			var loginUser =  _accountDataAccess.GetLoginMemberData(accountEmail);

			if (loginUser?.Session == null || loginUser?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "highlights",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};


			return View(model);
        }

        public IActionResult Lore()
        {
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

			var loginUser =  _accountDataAccess.GetLoginMemberData(accountEmail);

			if (loginUser?.Session == null || loginUser?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "lore",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};
			return View(model);
        }

		public IActionResult Edit(string? menuIn)
        {
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

			var loginUser =  _accountDataAccess.GetLoginMemberData(accountEmail);

			if (loginUser?.Session == null || loginUser?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn ?? "characters",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};

			return View(model);
        }
    }
}
