using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Models.InputModels;
using Winterra.Models.ViewModels;
using System.Security.Claims;
using Winterra.Helpers;
using Winterra.Models.DataModels;


namespace Winterra.Controllers
{
    [ValidateSession]
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
			var loginUser = HttpContext.Items["LoginUser"] as Account;
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
            var loginUser = HttpContext.Items["LoginUser"] as Account;
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
			var loginUser = HttpContext.Items["LoginUser"] as Account;
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
			var loginUser = HttpContext.Items["LoginUser"] as Account;
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
			var loginUser = HttpContext.Items["LoginUser"] as Account;
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
			var loginUser = HttpContext.Items["LoginUser"] as Account;
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
            var loginUser = HttpContext.Items["LoginUser"] as Account;
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
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new ContentEditViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn ?? "features",
                MenuTitle = "Content Management",
				Types = ContentEditViewModel.AvailableTypes,
				Content = _contentDataAccess.GetContentData(id),
				LoginUserInfo = loginUser
			};

			return View(model);
        }
    }
}
