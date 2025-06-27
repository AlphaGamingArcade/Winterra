using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.Areas.Admin.Models.ViewModels;
using Winterra.DataContexts;
using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Controllers
{
    [Authorize]
    [ValidateSession]
    public class ContentController : BaseController
    {
        private readonly ContentDataAccess _contentDataAccess;

        public ContentController(ContentDataAccess contentDataAccess)
        {
            _contentDataAccess = contentDataAccess;
        }

        public IActionResult Characters(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "characters";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Highlights(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "highlights";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Lore(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "lore";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Stellar(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "stellar";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Events(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "events";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Features(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "features";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult News(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "news";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Updates(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "updates";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult CodeOfConduct(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "code-of-conduct";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult TermsOfUse(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "terms-of-use";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult PrivacyPolicy(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "privacy-policy";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        public IActionResult Playbook(int? pageNumber, int? pageSize, string? search, string? sortBy, DateTime? startDate, DateTime? finishDate)
        {
            string menuIn = "playbook";
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            // Pagination config
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "content_published_at";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            int total = _contentDataAccess.GetContentCount(menuIn, search, startDate, finishDate);
            var paged = _contentDataAccess.GetContentListPaged(currentPage, currentPageSize, menuIn, search, currentOrderBy, currentSortBy, startDate, finishDate);

            var model = new ContentViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn,
                MenuTitle = "Content Management",
                ContentList = new Pagination<Content>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                StartDate = startDate,
                FinishDate = finishDate,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        [HttpGet]
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
                "characters" => nameof(Characters),
                "highlights" => nameof(Highlights),
                "lore" => nameof(Lore),
                "features" => nameof(Features),
                "news" => nameof(News),
                "updates" => nameof(Updates),
                "code-of-conduct" => nameof(CodeOfConduct),
                "terms-of-use" => nameof(TermsOfUse),
                "privacy-policy" => nameof(PrivacyPolicy),
                "playbook" => nameof(Playbook),
                _ => nameof(Features)
            };
            return RedirectToAction(redirectTo, new { menuIn });
        }

        [HttpGet]
        public IActionResult Create(string? menuIn)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new ContentCreateViewModel
            {
                MenuOut = 2,
                MenuIn = menuIn ?? "features",
                MenuTitle = "Content Management",
                Types = ContentCreateViewModel.AvailableTypes,
                Content = new Content
                {
                    Type = menuIn,
                    PublishedAt = DateTime.Now
                },
                LoginUserInfo = loginUser
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string? menuIn, Content content)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            if (!ModelState.IsValid)
            {
                var model = new ContentCreateViewModel
                {
                    MenuOut = 2,
                    MenuIn = menuIn ?? "characters",
                    MenuTitle = "Content Management",
                    Types = ContentCreateViewModel.AvailableTypes,
                    Content = content,
                    LoginUserInfo = loginUser
                };
                return View(model);
            }

            _contentDataAccess.SaveNewContent(content);

            var redirectTo = menuIn switch
            {
                "characters" => nameof(Characters),
                "highlights" => nameof(Highlights),
                "lore" => nameof(Lore),
                "features" => nameof(Features),
                "news" => nameof(News),
                "updates" => nameof(Updates),
                "code-of-conduct" => nameof(CodeOfConduct),
                "terms-of-use" => nameof(TermsOfUse),
                "privacy-policy" => nameof(PrivacyPolicy),
                "playbook" => nameof(Playbook),
                "stellar" => nameof(Stellar),
                "events" => nameof(Events),
                _ => nameof(Features)
            };
            return RedirectToAction(redirectTo, new { menuIn });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string? menuIn, int id)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            _contentDataAccess.DeleteContentData(id);

            var redirectTo = menuIn switch
            {
                "characters" => nameof(Characters),
                "highlights" => nameof(Highlights),
                "lore" => nameof(Lore),
                "features" => nameof(Features),
                "news" => nameof(News),
                "updates" => nameof(Updates),
                "code-of-conduct" => nameof(CodeOfConduct),
                "terms-of-use" => nameof(TermsOfUse),
                "privacy-policy" => nameof(PrivacyPolicy),
                "playbook" => nameof(Playbook),
                "stellar" => nameof(Stellar),
                "events" => nameof(Events),
                _ => nameof(Features)
            };
            return RedirectToAction(redirectTo, new { menuIn });
        }
    } 
}