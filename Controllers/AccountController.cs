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
		private readonly ContentDataAccess _contentDataAccess;
		private readonly PreviewDataAccess _previewDataAccess;

		public AccountController(AccountDataAccess accountDataAccess, ContentDataAccess contentDataAccess, PreviewDataAccess previewDataAccess)
        {
			this._accountDataAccess = accountDataAccess;
			this._contentDataAccess = contentDataAccess;
			this._previewDataAccess = previewDataAccess;
		}

        public IActionResult Index(string? menuIn)
        {
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

			var loginUser =  _accountDataAccess.GetLoginMemberData(accountEmail);

			if (loginUser?.Session == null || loginUser?.Session != accountSession)
				return RedirectToAction("Logout", "Account");


            var model = new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = menuIn ?? "user",
                MenuTitle = "Account Management",
                UserAccountList = _accountDataAccess.GetAccountList( menuIn == "user" ? 0 : 1),
				LoginUserInfo = loginUser
			};

			return View(model);
        }

        public IActionResult Administrator()
        {
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

			var loginUser =  _accountDataAccess.GetLoginMemberData(accountEmail);

			if (loginUser?.Session == null || loginUser?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

            var model = new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = "administrator",
                MenuTitle = "Account Management",
                AdminAccountList = _accountDataAccess.GetAccountList(1),
				LoginUserInfo = loginUser
			};

			return View(model);
        }
        
        [HttpGet]
        public IActionResult Edit(string? menuIn, int id){
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

			var loginUser =  _accountDataAccess.GetLoginMemberData(accountEmail);

			if (loginUser?.Session == null || loginUser?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

            var model = new AccountEditViewModel
            {
                MenuOut = 1,
                MenuIn = menuIn ?? "user",
                MenuTitle = "Account Management",
                Account = _accountDataAccess.GetAccountData(id),
				LoginUserInfo = loginUser
			};
            
            if (model.Account == null){
                return NotFound();
            }

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string? menuIn, int id, Account account)
        {
            string? accountEmail = null;
            string? accountSession = null;

            if (HttpContext.User.Identity?.IsAuthenticated == true)
            {
                accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
                accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
            }

            var loginUser = _accountDataAccess.GetLoginMemberData(accountEmail);

            if (loginUser?.Session != accountSession)
                return RedirectToAction("Logout", "Account");

            if (!ModelState.IsValid)
            {
                // repopulate the full view model for redisplay
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

            return RedirectToAction(nameof(Index), new { menuIn });
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
                        new Claim(ClaimTypes.Hash, session),
                        new Claim(ClaimTypes.Role, Roles.Admin)
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
