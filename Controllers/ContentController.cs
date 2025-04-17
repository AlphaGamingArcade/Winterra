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

        [ValidateSession]
        public IActionResult Features()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "features",
                MenuTitle = "Content Management",
                FeatureContentList = _contentDataAccess.GetContentList("features"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }   

        [ValidateSession]
        public IActionResult News()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "news",
                MenuTitle = "Content Management",
                NewsContentList = _contentDataAccess.GetContentList("news"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [ValidateSession]
        public IActionResult Update()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "update",
                MenuTitle = "Content Management",
                UpdateContentList = _contentDataAccess.GetContentList("update"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [ValidateSession]
        public IActionResult CodeOfConduct()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "code-of-conduct",
                MenuTitle = "Content Management",
                CodeOfConductContentList = _contentDataAccess.GetContentList("code-of-conduct"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [ValidateSession]
        public IActionResult TermsOfUse()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "terms-of-use",
                MenuTitle = "Content Management",
                TermsOfUseContentList = _contentDataAccess.GetContentList("terms-of-use"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [ValidateSession]
        public IActionResult PrivacyPolicy()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "privacy-policy",
                MenuTitle = "Content Management",
                PrivacyPolicyContentList = _contentDataAccess.GetContentList("privacy-policy"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [ValidateSession]
        public IActionResult Playbook()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "playbook",
                MenuTitle = "Content Management",
                PlaybookContentList = _contentDataAccess.GetContentList("playbook"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [HttpGet]
        [ValidateSession]
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

        [HttpPost]
        [ValidateSession]
        [ValidateAntiForgeryToken]
		public IActionResult Edit(string? menuIn, int? id, Content content)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            if (!ModelState.IsValid)
            {
                var viewModel = new ContentEditViewModel
                {
                    MenuOut = 1,
                    MenuIn = menuIn ?? "features",
                    MenuTitle = "Content Management",
                    Content = content, 
                    LoginUserInfo = loginUser
                };
                return View(viewModel);
            }

            _contentDataAccess.UpdateAfterEdit(content);

            var redirectTo = menuIn switch
            {
                "features" => nameof(Features),
                "news" => nameof(News),
                "update" => nameof(Update),
                "code-of-conduct" => nameof(CodeOfConduct),
                "terms-of-use" => nameof(TermsOfUse),
                "privacy-policy" => nameof(PrivacyPolicy),
                "playbook" => nameof(Playbook),
                _ => nameof(Features)
            };
            return RedirectToAction(redirectTo, new { menuIn });
        }
    }
}
