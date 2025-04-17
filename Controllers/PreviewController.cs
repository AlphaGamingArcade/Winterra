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

		[ValidateSession]
        public IActionResult Characters()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new PreviewViewModel
            {
                MenuOut = 2,
                MenuIn = "characters",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};

			return View(model);
        }

		[ValidateSession]
        public IActionResult Highlights()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new PreviewViewModel
            {
                MenuOut = 2,
                MenuIn = "highlights",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};


			return View(model);
        }

		[ValidateSession]
        public IActionResult Lore()
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new PreviewViewModel
            {
                MenuOut = 2,
                MenuIn = "lore",
                MenuTitle = "Content Management",
				LoginUserInfo = loginUser
			};
			return View(model);
        }

		[HttpGet]
		[ValidateSession]
		public IActionResult Edit(string? menuIn, int? id)
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new PreviewEditViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn ?? "characters",
                MenuTitle = "Content Management",
				Types = PreviewEditViewModel.AvailableTypes,
				Preview = _previewDataAccess.GetPreviewData(id),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

		
		[HttpPost]
		[ValidateSession]
		public IActionResult Edit(string? menuIn, int? id, Preview preview)
        {
			var loginUser = HttpContext.Items["LoginUser"] as Account;
            if (!ModelState.IsValid)
            {
                // repopulate the full view model for redisplay
                var viewModel = new PreviewEditViewModel
                {
                    MenuOut = 2,
					MenuIn = menuIn ?? "characters",
					MenuTitle = "Content Management",
					Types = PreviewEditViewModel.AvailableTypes,
					Preview = preview,
					LoginUserInfo = loginUser
                };

                return View(viewModel);
            }

            _previewDataAccess.UpdateAfterEdit(preview);

            return RedirectToAction(nameof(Characters), new { menuIn });
        }
    }
}
