

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Winterra.Areas.Admin.Models.ViewModels;
using Winterra.DataContexts;
using Winterra.Helpers;
using Winterra.Models.DataModels;
using Winterra.Models.InputModels;

namespace Winterra.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly AccountDataAccess _accountDataAccess;

        public AccountController(AccountDataAccess accountDataAccess)
        {
            _accountDataAccess = accountDataAccess;
        }

        [Authorize(AuthenticationSchemes = "Auth")]
        [AttachLoginUser]
        public IActionResult Index(int? pageNumber, int? pageSize, string? search, string? sortBy)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 30;
            string currentOrderBy = "id";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            var total = _accountDataAccess.GetAccountCount(0, search);
            var paged = _accountDataAccess.GetAccountListPaged(currentPage, currentPageSize, 0, search, currentOrderBy, currentSortBy);

            var model = new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = "user",
                MenuTitle = "Account Management",
                UserAccountList = new Pagination<Account>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                LoginUserInfo = loginUser
            };

            return View(model);
        }

        [Authorize(AuthenticationSchemes = "Auth")]
        [AttachLoginUser]
        public IActionResult Administrator(int? pageNumber, int? pageSize, string? search, string? sortBy)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            string currentOrderBy = "id";
            string currentSortBy = sortBy == "oldest" ? "asc" : "desc";

            var total = _accountDataAccess.GetAccountCount(1, search);
            var paged = _accountDataAccess.GetAccountListPaged(currentPage, currentPageSize, 1, search, currentOrderBy, currentSortBy);

            var model = new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = "administrator",
                MenuTitle = "Account Management",
                AdminAccountList = new Pagination<Account>(paged, total, currentPage, currentPageSize),
                Search = search,
                SortBy = sortBy,
                LoginUserInfo = loginUser
            };
            return View(model);
        }

        [HttpGet]
        [AttachLoginUser]
        public IActionResult Edit(string? menuIn, int id)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            var model = new AccountEditViewModel
            {
                MenuOut = 1,
                MenuIn = menuIn ?? "user",
                MenuTitle = "Account Management",
                Account = _accountDataAccess.GetAccountData(id),
                LoginUserInfo = loginUser
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AttachLoginUser]
        public IActionResult Edit(string? menuIn, Account account)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;
            if (!ModelState.IsValid)
            {
                var viewModel = new AccountEditViewModel
                {
                    MenuOut = 1,
                    MenuIn = menuIn ?? "user",
                    MenuTitle = "Account Management",
                    Account = account,
                    LoginUserInfo = loginUser
                };

                return View(viewModel);
            }

            _accountDataAccess.UpdateAfterEdit(account);

            var redirectTo = menuIn switch
            {
                "user" => nameof(Index),
                "administrator" => nameof(Administrator),
                _ => nameof(Index),
            };
            return RedirectToAction(redirectTo, new { menuIn });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login member)
        {
            if (ModelState.IsValid)
            {
                bool isLogin = _accountDataAccess.CheckLogin(member);
                if (isLogin)
                {
                    var nowDate = DateTime.Now.ToString();
                    var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
                    var session = HashHelper.ComputeSHA256(member.Email + nowDate + ipAddress);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, member.Email),
                        new Claim(ClaimTypes.Hash, session)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Auth");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync("Auth", claimsPrincipal);

                    _accountDataAccess.UpdateAfterLogin(member.Email, session);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(member);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            string? email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            await HttpContext.SignOutAsync();

            if (email != null)
                _accountDataAccess.UpdateAfterLogout(email);

            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
