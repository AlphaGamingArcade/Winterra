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
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        public IActionResult UserPartial(){
            var model = new AccountTablePartialModel{    
                Title = "User",
                AccountCount = _accountDataAccess.GetAccountCount(),
                AccountList = _accountDataAccess.GetAccountList()
            };
            return PartialView("_AccountTable", model);
        }

        public IActionResult AdministratorPartial(){
            var model = new AccountTablePartialModel{    
                Title = "Administrator",
                AccountCount = _accountDataAccess.GetAccountCount(1),
                AccountList = _accountDataAccess.GetAccountList(1)
            };
            return PartialView("_AccountTable", model);
        }

        public IActionResult CharactersPartial(){
            var model = new ContentTablePartialModel{    
                Title = "Characters",
                CharacterList = _previewDataAccess.GetPreviewList("characters"),
            };
            return PartialView("_ContentTable", model);
        }
       
        public IActionResult HighlightsPartial(){
            var model = new ContentTablePartialModel{    
                Title = "Highlights",
                HighlightList = _previewDataAccess.GetPreviewList("highlights"),
            };
            return PartialView("_ContentTable", model);
        }

        public IActionResult LorePartial(){
            var model = new ContentTablePartialModel{    
                Title = "Lore",
                LoreList = _previewDataAccess.GetPreviewList("lore"),
            };
            return PartialView("_ContentTable", model);
        }

        public IActionResult FeaturesPartial(){
            var model = new ContentTablePartialModel{    
                Title = "Features",
                FeaturesList = _previewDataAccess.GetPreviewList("features"),
            };
            return PartialView("_ContentTable", model);
        }

        public IActionResult NewsPartial(){
            var model = new ContentTablePartialModel{    
                Title = "News",
                NewsList = _contentDataAccess.GetContentList("news"),
            };
            return PartialView("_ContentTable", model);
        }

        public IActionResult UpdatePartial(){
            var model = new ContentTablePartialModel{    
                Title = "Update",
                UpdateList = _contentDataAccess.GetContentList("update"),
            };
            return PartialView("_ContentTable", model);
        }

        public IActionResult CodeOfConductPartial(){
            var model = new ContentTablePartialModel{    
                Title = "Code of Conduct",
                CodeOfConductList = _contentDataAccess.GetContentList("code-of-conduct"),
            };
            return PartialView("_ContentTable", model);
        }

        public IActionResult TermsOfUsePartial(){
            var model = new ContentTablePartialModel{    
                Title = "Terms of Use",
                TermsOfUseList = _contentDataAccess.GetContentList("terms-of-use"),
            };
            return PartialView("_ContentTable", model);
        }

        public IActionResult PrivacyPolicyPartial(){
            var model = new ContentTablePartialModel{    
                Title = "Privacy Policy",
                PrivacyPolicyList = _contentDataAccess.GetContentList("privacy-policy"),
            };
            return PartialView("_ContentTable", model);
        }

        public IActionResult PlaybookPartial(){
            var model = new ContentTablePartialModel{    
                Title = "Playbook",
                PlaybookList = _contentDataAccess.GetContentList("playbook"),
            };
            return PartialView("_ContentTable", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
