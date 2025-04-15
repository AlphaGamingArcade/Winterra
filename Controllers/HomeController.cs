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
		private readonly AuthDataAccess _authDataAcces;
		private readonly ContentDataAccess _contentDataAccess;
		private readonly PreviewDataAccess _previewDataAccess;
        private readonly CharacterDataAccess _characterDataAccess;

		public HomeController(AuthDataAccess authDataAcces, ContentDataAccess contentDataAccess, PreviewDataAccess previewDataAccess, CharacterDataAccess characterDataAccess)
        {
			this._authDataAcces = authDataAcces;
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
                MenuOut = 1,
                MenuIn = "main",
                MenuTitle = "Main title",
                CharacterList = _characterDataAccess.GetCharacterList(),
				ContentList = _contentDataAccess.GetContentList(),
                PreviewList = _previewDataAccess.GetPreviewList(),
				LoginUserInfo = _authDataAcces.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Auth");

			return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
