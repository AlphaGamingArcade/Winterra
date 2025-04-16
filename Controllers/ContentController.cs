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
    public class ContentController : Controller
    {
		private readonly AccountDataAccess _accountDataAccess;
		private readonly ContentDataAccess _contentDataAccess;
		private readonly PreviewDataAccess _previewDataAccess;

		public ContentController(AccountDataAccess accountDataAccess, ContentDataAccess contentDataAccess, PreviewDataAccess previewDataAccess)
        {
			this._accountDataAccess = accountDataAccess;
			this._contentDataAccess = contentDataAccess;
			this._previewDataAccess = previewDataAccess;
		}

        public IActionResult Features()
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
                MenuIn = "features",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};

			return View(model);
        }   

        public IActionResult News()
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
                MenuIn = "news",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};

			return View(model);
        }


        public IActionResult Update()
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
                MenuIn = "update",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        public IActionResult CodeOfConduct()
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
                MenuIn = "code-of-conduct",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        public IActionResult TermsOfUse()
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
                MenuIn = "terms-of-use",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};

			return View(model);
        }
        public IActionResult PrivacyPolicy()
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
                MenuIn = "privacy-policy",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};

			return View(model);
        }
        public IActionResult Playbook()
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
                MenuIn = "playbook",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};

			return View(model);
        }

		public IActionResult Edit(string? menuIn, int? id)
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

            var model = new ContentEditViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn ?? "features",
                MenuTitle = "Content Management",
				Content = _contentDataAccess.GetContentData(id),
				LoginUserInfo = loginUser
			};

			return View(model);
        }
    }
}
