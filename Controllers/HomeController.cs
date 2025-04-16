using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Helpers;
using Winterra.Models.ViewModels;
using Winterra.Models.PartialModels;
using System.Diagnostics;
using System.Security.Claims;


namespace Winterra.Controllers
{
    public class HomeController : Controller
    {
		private readonly AccountDataAccess _accountDataAccess;
		private readonly ContentDataAccess _contentDataAccess;
		private readonly PreviewDataAccess _previewDataAccess;

		public HomeController(AccountDataAccess accountDataAccess, ContentDataAccess contentDataAccess, PreviewDataAccess previewDataAccess)
        {
			this._accountDataAccess = accountDataAccess;
			this._contentDataAccess = contentDataAccess;
			this._previewDataAccess = previewDataAccess;
		}

        [Authorize(Roles = Roles.Admin)]
		public IActionResult Index()
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
                MenuOut = 1,
                MenuIn = "user",
                MenuTitle = "Account Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult Administrator()
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
                MenuOut = 1,
                MenuIn = "administrator",
                MenuTitle = "Account Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult Characters()
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
                MenuIn = "characters",
                MenuTitle = "Account Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult Highlights()
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
                MenuIn = "highlights",
                MenuTitle = "Content Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult Lore()
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
                MenuIn = "lore",
                MenuTitle = "Content Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult Features()
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
                MenuIn = "features",
                MenuTitle = "Content Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult News()
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
                MenuIn = "news",
                MenuTitle = "Content Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult Update()
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
                MenuIn = "update",
                MenuTitle = "Content Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult CodeOfConduct()
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
                MenuIn = "code-of-conduct",
                MenuTitle = "Content Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult TermsOfUse()
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
                MenuIn = "terms-of-use",
                MenuTitle = "Content Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult PrivacyPolicy()
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
                MenuIn = "privacy-policy",
                MenuTitle = "Content Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		public IActionResult Playbook()
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
                MenuIn = "playbook",
                MenuTitle = "Content Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
