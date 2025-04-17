using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Helpers;
using Winterra.Models.ViewModels;
using System.Diagnostics;
using System.Security.Claims;
using Winterra.Models.DataModels;


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
		[ValidateSession]
		public IActionResult Index()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 1,
                MenuIn = "user",
                MenuTitle = "Account Management",
				UserAccountList = _accountDataAccess.GetAccountList(0),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult Administrator()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 1,
                MenuIn = "administrator",
                MenuTitle = "Account Management",
				AdminAccountList = _accountDataAccess.GetAccountList(1),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult Characters()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "characters",
                MenuTitle = "Content Management",
				CharacterPreviewList = _previewDataAccess.GetPreviewList("characters"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult Highlights()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "highlights",
                MenuTitle = "Content Management",
				HighlightPreviewList = _previewDataAccess.GetPreviewList("highlights"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult Lore()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "lore",
                MenuTitle = "Content Management",
				LorePreviewList = _previewDataAccess.GetPreviewList("lore"),
				LoginUserInfo = loginUser
			};
			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult Features()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "features",
                MenuTitle = "Content Management",
				FeatureContentList = _contentDataAccess.GetContentList("features"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult News()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "news",
                MenuTitle = "Content Management",
				NewsContentList = _contentDataAccess.GetContentList("news"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult Update()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "update",
                MenuTitle = "Content Management",
				UpdateContentList = _contentDataAccess.GetContentList("update"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult CodeOfConduct()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "code-of-conduct",
                MenuTitle = "Content Management",
				CodeOfConductContentList = _contentDataAccess.GetContentList("code-of-conduct"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult TermsOfUse()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "terms-of-use",
                MenuTitle = "Content Management",
				TermsOfUseContentList = _contentDataAccess.GetContentList("terms-of-use"),
				LoginUserInfo = loginUser
			};
			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult PrivacyPolicy()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "privacy-policy",
                MenuTitle = "Content Management",
				PrivacyPolicyContentList = _contentDataAccess.GetContentList("privacy-policy"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
		[ValidateSession]
		public IActionResult Playbook()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeViewModel
            {
                MenuOut = 2,
                MenuIn = "playbook",
                MenuTitle = "Content Management",
				PlaybookContentList = _contentDataAccess.GetContentList("playbook"),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
