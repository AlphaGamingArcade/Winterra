using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Models.InputModels;
using System.Security.Claims;
using Winterra.Helpers;
using Winterra.Models.ViewModels;
using Winterra.Models.DataModels;

namespace Winterra.Controllers
{
    public class AccountController : Controller
    {
		private readonly AccountDataAccess _accountDataAccess;

		public AccountController(AccountDataAccess accountDataAccess)
        {
			this._accountDataAccess = accountDataAccess;
		}

        
        [ValidateSession]
        public IActionResult Index(int? pageNumber, int? pageSize)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _accountDataAccess.GetAccountCount(0);
            var paged = _accountDataAccess.GetAccountListPaged(currentPage, currentPageSize, 0);

            var model = new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = "user",
                MenuTitle = "Account Management",
                UserAccountList = new Pagination<Account>(paged, total, currentPage, currentPageSize),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        [ValidateSession]
        public IActionResult Administrator(int? pageNumber, int? pageSize)
        {
            var loginUser = HttpContext.Items["LoginUser"] as Account;

            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;
            int total = _accountDataAccess.GetAccountCount(1);
            var paged = _accountDataAccess.GetAccountListPaged(currentPage, currentPageSize, 1);
            var model = new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = "administrator",
                MenuTitle = "Account Management",
                AdminAccountList = new Pagination<Account>(paged, total, currentPage, currentPageSize),
				LoginUserInfo = loginUser
			};
			return View(model);
        }
        
        [HttpGet]
        [ValidateSession]
        public IActionResult Edit(string? menuIn, int id){
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
        [ValidateSession]
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
                        new Claim(ClaimTypes.Name, member.Email),
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
            string? account = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            await HttpContext.SignOutAsync();

            if (account != null)
                _accountDataAccess.UpdateAfterLogout(account);

            return RedirectToAction("Index", "Home");
        }
    }
}
