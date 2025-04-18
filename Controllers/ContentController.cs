using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Models.ViewModels;
using Winterra.Models.DataModels;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [ValidateSession]
        public IActionResult Features(int? pageNumber, int? pageSize)
        {
            string menuIn = "features";
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _contentDataAccess.GetContentCount(menuIn);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn);
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                FeatureContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
				LoginUserInfo = loginUser
			};

			return View(model);
        }   

        [Authorize]
        [ValidateSession]
        public IActionResult News(int? pageNumber, int? pageSize)
        {
            string menuIn = "features";
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _contentDataAccess.GetContentCount(menuIn);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn);
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = "news",
                MenuTitle = "Content Management",
                NewsContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize]
        [ValidateSession]
        public IActionResult Update(int? pageNumber, int? pageSize)
        {
			 string menuIn = "update";
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _contentDataAccess.GetContentCount(menuIn);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn);
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                UpdateContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize]
        [ValidateSession]
        public IActionResult CodeOfConduct(int? pageNumber, int? pageSize)
        {
			string menuIn = "code-of-conduct";
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _contentDataAccess.GetContentCount(menuIn);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn);
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                CodeOfConductContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize]
        [ValidateSession]
        public IActionResult TermsOfUse(int? pageNumber, int? pageSize)
        {
			string menuIn = "terms-of-use";
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _contentDataAccess.GetContentCount(menuIn);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn);
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                TermsOfUseContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize]
        [ValidateSession]
        public IActionResult PrivacyPolicy(int? pageNumber, int? pageSize)
        {
			string menuIn = "privacy-policy";
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _contentDataAccess.GetContentCount(menuIn);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn);
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                PrivacyPolicyContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [Authorize]
        [ValidateSession]
        public IActionResult Playbook(int? pageNumber, int? pageSize)
        {
            string menuIn = "playbook";
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _contentDataAccess.GetContentCount(menuIn);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn);
            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                PlaybookContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
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
