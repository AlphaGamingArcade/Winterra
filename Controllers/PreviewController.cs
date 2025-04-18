using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Models.ViewModels;
using Winterra.Models.DataModels;

namespace Winterra.Controllers
{
    [Authorize]
    [ValidateSession]
    public class PreviewController : Controller
    {
        private readonly PreviewDataAccess _previewDataAccess;

        public PreviewController(PreviewDataAccess previewDataAccess)
        {
            this._previewDataAccess = previewDataAccess;
        }

        [Authorize]
        public IActionResult Characters(int? pageNumber, int? pageSize)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _previewDataAccess.GetPreviewCount("characters");
            var paged = _previewDataAccess.GetPreviewListPaged(currentPage, currentPageSize, "characters");

            var model = new PreviewViewModel
            {
                MenuOut = 2,
                MenuIn = "characters",
                MenuTitle = "Content Management",
                CharacterPreviewList = new Pagination<Preview>(paged, total, currentPage, currentPageSize),
                LoginUserInfo = loginUser
            };
            return View(model);
        }

        [Authorize]
        public IActionResult Highlights(int? pageNumber, int? pageSize)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _previewDataAccess.GetPreviewCount("highlights");
            var paged = _previewDataAccess.GetPreviewListPaged(currentPage, currentPageSize, "highlights");
            var model = new PreviewViewModel
            {
                MenuOut = 2,
                MenuIn = "highlights",
                MenuTitle = "Content Management",
                HighlightPreviewList = new Pagination<Preview>(paged, total, currentPage, currentPageSize),
                LoginUserInfo = loginUser
            };


            return View(model);
        }

        [Authorize]
        public IActionResult Lore(int? pageNumber, int? pageSize)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _previewDataAccess.GetPreviewCount("lore");
            var paged = _previewDataAccess.GetPreviewListPaged(currentPage, currentPageSize, "lore");
            var model = new PreviewViewModel
            {
                MenuOut = 2,
                MenuIn = "lore",
                MenuTitle = "Content Management",
                LorePreviewList = new Pagination<Preview>(paged, total, currentPage, currentPageSize),
                LoginUserInfo = loginUser
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(string? menuIn, int? id)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var preview = _previewDataAccess.GetPreviewData(id);

            var model = new PreviewEditViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn ?? "characters",
                MenuTitle = "Content Management",
                Types = PreviewEditViewModel.AvailableTypes,
                Preview = preview,
                LoginUserInfo = loginUser
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string? menuIn, Preview preview)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            if (!ModelState.IsValid)
            {
                var model = new PreviewEditViewModel
                {
                    MenuOut = 2,
                    MenuIn = menuIn ?? "characters",
                    MenuTitle = "Content Management",
                    Types = PreviewEditViewModel.AvailableTypes,
                    Preview = preview,
                    LoginUserInfo = loginUser
                };

                return View(model);
            }

            _previewDataAccess.UpdateAfterEdit(preview);

            var redirectTo = menuIn switch
            {
                "characters" => nameof(Characters),
                "highlights" => nameof(Highlights),
                "lore" => nameof(Lore),
                _ => nameof(Characters),
            };
            return RedirectToAction(redirectTo, new { menuIn });
        }

        [HttpGet]
        public IActionResult Create(string? menuIn, int? id)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new PreviewCreateViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn ?? "characters",
                MenuTitle = "Content Management",
                Types = PreviewCreateViewModel.AvailableTypes,
                Preview = new Preview
                {
                    Type = menuIn
                },
                LoginUserInfo = loginUser
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string? menuIn, Preview preview)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            if (!ModelState.IsValid)
            {
                var model = new PreviewCreateViewModel
                {
                    MenuOut = 2,
                    MenuIn = menuIn ?? "characters",
                    MenuTitle = "Content Management",
                    Types = PreviewCreateViewModel.AvailableTypes,
                    Preview = preview,
                    LoginUserInfo = loginUser
                };
                return View(model);
            }

            _previewDataAccess.SaveNewPreview(preview);

            var redirectTo = menuIn switch
            {
                "characters" => nameof(Characters),
                "highlights" => nameof(Highlights),
                "lore" => nameof(Lore),
                _ => nameof(Characters),
            };
            return RedirectToAction(redirectTo, new { menuIn });
        }
    }
}
