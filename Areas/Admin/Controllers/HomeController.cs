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

        public IActionResult Characters()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "characters",
                MenuTitle = "Content Management",
                CharacterContentList = _contentDataAccess.GetContentList("characters"),
            };

            return View(model);
        }

        public IActionResult Highlights()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "highlights",
                MenuTitle = "Content Management",
                HighlightContentList = _contentDataAccess.GetContentList("highlights"),
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Lore()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "lore",
                MenuTitle = "Content Management",
                LoreContentList = _contentDataAccess.GetContentList("lore"),
                LoginUserInfo = loginUser
            };
            return View(model);
        }

        public IActionResult Features()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "features",
                MenuTitle = "Content Management",
                FeatureContentList = _contentDataAccess.GetContentList("features"),
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult News()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "news",
                MenuTitle = "Content Management",
                NewsContentList = _contentDataAccess.GetContentList("news"),
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Update()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "update",
                MenuTitle = "Content Management",
                UpdateContentList = _contentDataAccess.GetContentList("update"),
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult CodeOfConduct()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "code-of-conduct",
                MenuTitle = "Content Management",
                CodeOfConductContentList = _contentDataAccess.GetContentList("code-of-conduct"),
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult TermsOfUse()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "terms-of-use",
                MenuTitle = "Content Management",
                TermsOfUseContentList = _contentDataAccess.GetContentList("terms-of-use"),
                LoginUserInfo = loginUser
                
            };
            return View(model);
        }

        public IActionResult PrivacyPolicy()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "privacy-policy",
                MenuTitle = "Content Management",
                PrivacyPolicyContentList = _contentDataAccess.GetContentList("privacy-policy"),
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Playbook()
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new HomeIndexViewModel
            {
                MenuOut = 2,
                MenuIn = "playbook",
                MenuTitle = "Content Management",
                PlaybookContentList = _contentDataAccess.GetContentList("playbook"),
                LoginUserInfo = loginUser
            };

            return View(model);
        }
    } 
}